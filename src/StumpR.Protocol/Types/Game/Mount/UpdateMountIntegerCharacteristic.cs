using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class UpdateMountIntegerCharacteristic : UpdateMountCharacteristic
{
    public new const short Id = 305;

    public UpdateMountIntegerCharacteristic(sbyte type, int value)
    {
        Type = type;
        Value = value;
    }

    public UpdateMountIntegerCharacteristic()
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