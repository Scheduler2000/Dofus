using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectString : ObjectEffect
{
    public new const short Id = 576;

    public ObjectEffectString(ushort actionId, string value)
    {
        ActionId = actionId;
        Value = value;
    }

    public ObjectEffectString()
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