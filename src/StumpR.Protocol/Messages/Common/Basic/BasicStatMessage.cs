using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicStatMessage : Message
{
    public const uint Id = 514;

    public BasicStatMessage(double timeSpent, ushort statId)
    {
        TimeSpent = timeSpent;
        StatId = statId;
    }

    public BasicStatMessage()
    {
    }

    public override uint MessageId => Id;

    public double TimeSpent { get; set; }

    public ushort StatId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(TimeSpent);
        writer.WriteVarUShort(StatId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TimeSpent = reader.ReadDouble();
        StatId = reader.ReadVarUShort();
    }
}