using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class UpdateMountBooleanCharacteristic : UpdateMountCharacteristic
{
    public new const short Id = 1756;

    public UpdateMountBooleanCharacteristic(sbyte type, bool value)
    {
        Type = type;
        Value = value;
    }

    public UpdateMountBooleanCharacteristic()
    {
    }

    public override short TypeId => Id;

    public bool Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadBoolean();
    }
}