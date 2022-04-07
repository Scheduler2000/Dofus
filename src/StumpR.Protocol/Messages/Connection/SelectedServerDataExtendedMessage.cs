using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SelectedServerDataExtendedMessage : SelectedServerDataMessage
{
    public new const uint Id = 2850;

    public SelectedServerDataExtendedMessage(ushort serverId,
        string address,
        IEnumerable<ushort> ports,
        bool canCreateNewCharacter,
        IEnumerable<sbyte> ticket,
        IEnumerable<GameServerInformations> servers)
    {
        ServerId = serverId;
        Address = address;
        Ports = ports;
        CanCreateNewCharacter = canCreateNewCharacter;
        Ticket = ticket;
        Servers = servers;
    }

    public SelectedServerDataExtendedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameServerInformations> Servers { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Servers.Count());
        foreach (GameServerInformations objectToSend in Servers) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort serversCount = reader.ReadUShort();
        var servers_ = new GameServerInformations[serversCount];

        for (var serversIndex = 0; serversIndex < serversCount; serversIndex++)
        {
            var objectToAdd = new GameServerInformations();
            objectToAdd.Deserialize(reader);
            servers_[serversIndex] = objectToAdd;
        }
        Servers = servers_;
    }
}