using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class StatisticDataString : StatisticData
{
    public new const short Id = 6983;

    public StatisticDataString(string value)
    {
        Value = value;
    }

    public StatisticDataString()
    {
    }

    public override short TypeId => Id;

    public string Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadUTF();
    }
}