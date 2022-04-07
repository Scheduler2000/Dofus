using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectInteger : ObjectEffect
{
    public new const short Id = 2163;

    public ObjectEffectInteger(ushort actionId, uint value)
    {
        ActionId = actionId;
        Value = value;
    }

    public ObjectEffectInteger()
    {
    }

    public override short TypeId => Id;

    public uint Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadVarUInt();
    }
}