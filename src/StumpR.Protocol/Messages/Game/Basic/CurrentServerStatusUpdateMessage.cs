using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CurrentServerStatusUpdateMessage : Message
{
    public const uint Id = 547;

    public CurrentServerStatusUpdateMessage(sbyte status)
    {
        Status = status;
    }

    public CurrentServerStatusUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Status { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Status);
    }

    public override void Deserialize(IDataReader reader)
    {
        Status = reader.ReadSByte();
    }
}