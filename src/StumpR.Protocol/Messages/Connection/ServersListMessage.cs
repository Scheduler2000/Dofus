using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ServersListMessage : Message
{
    public const uint Id = 786;

    public ServersListMessage(IEnumerable<GameServerInformations> servers, ushort alreadyConnectedToServerId, bool canCreateNewCharacter)
    {
        Servers = servers;
        AlreadyConnectedToServerId = alreadyConnectedToServerId;
        CanCreateNewCharacter = canCreateNewCharacter;
    }

    public ServersListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameServerInformations> Servers { get; set; }

    public ushort AlreadyConnectedToServerId { get; set; }

    public bool CanCreateNewCharacter { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Servers.Count());
        foreach (GameServerInformations objectToSend in Servers) objectToSend.Serialize(writer);
        writer.WriteVarUShort(AlreadyConnectedToServerId);
        writer.WriteBoolean(CanCreateNewCharacter);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort serversCount = reader.ReadUShort();
        var servers_ = new GameServerInformations[serversCount];

        for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
        {
            var objectToAdd = new GameServerInformations();
            objectToAdd.Deserialize(reader);
            servers_[serversIndex] = objectToAdd;
        }
        Servers = servers_;
        AlreadyConnectedToServerId = reader.ReadVarUShort();
        CanCreateNewCharacter = reader.ReadBoolean();
    }
}