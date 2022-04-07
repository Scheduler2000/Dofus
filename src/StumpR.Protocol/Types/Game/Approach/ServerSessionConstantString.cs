using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ServerSessionConstantString : ServerSessionConstant
{
    public new const short Id = 8535;

    public ServerSessionConstantString(ushort objectId, string value)
    {
        ObjectId = objectId;
        Value = value;
    }

    public ServerSessionConstantString()
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