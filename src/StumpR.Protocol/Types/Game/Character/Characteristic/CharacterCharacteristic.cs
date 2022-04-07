using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterCharacteristic
{
    public const short Id = 4565;

    public CharacterCharacteristic(short characteristicId)
    {
        CharacteristicId = characteristicId;
    }

    public CharacterCharacteristic()
    {
    }

    public virtual short TypeId => Id;

    public short CharacteristicId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort(CharacteristicId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        CharacteristicId = reader.ReadShort();
    }
}