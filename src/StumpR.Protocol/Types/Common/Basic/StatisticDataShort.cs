using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class StatisticDataShort : StatisticData
{
    public new const short Id = 5872;

    public StatisticDataShort(short value)
    {
        Value = value;
    }

    public StatisticDataShort()
    {
    }

    public override short TypeId => Id;

    public short Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadShort();
    }
}