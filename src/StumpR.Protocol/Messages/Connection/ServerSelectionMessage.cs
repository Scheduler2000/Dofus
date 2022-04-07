using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ServerSelectionMessage : Message
{
    public const uint Id = 214;

    public ServerSelectionMessage(ushort serverId)
    {
        ServerId = serverId;
    }

    public ServerSelectionMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ServerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ServerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ServerId = reader.ReadVarUShort();
    }
}