using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ServerStatusUpdateMessage : Message
{
    public const uint Id = 1411;

    public ServerStatusUpdateMessage(GameServerInformations server)
    {
        Server = server;
    }

    public ServerStatusUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public GameServerInformations Server { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Server.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Server = new GameServerInformations();
        Server.Deserialize(reader);
    }
}