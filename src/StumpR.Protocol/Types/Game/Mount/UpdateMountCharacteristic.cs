using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class UpdateMountCharacteristic
{
    public const short Id = 826;

    public UpdateMountCharacteristic(sbyte type)
    {
        Type = type;
    }

    public UpdateMountCharacteristic()
    {
    }

    public virtual short TypeId => Id;

    public sbyte Type { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Type);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Type = reader.ReadSByte();
    }
}