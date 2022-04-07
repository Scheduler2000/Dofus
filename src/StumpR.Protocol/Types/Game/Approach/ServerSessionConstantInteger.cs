using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ServerSessionConstantInteger : ServerSessionConstant
{
    public new const short Id = 6620;

    public ServerSessionConstantInteger(ushort objectId, int value)
    {
        ObjectId = objectId;
        Value = value;
    }

    public ServerSessionConstantInteger()
    {
    }

    public override short TypeId => Id;

    public int Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadInt();
    }
}