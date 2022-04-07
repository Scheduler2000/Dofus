using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterCharacteristicValue : CharacterCharacteristic
{
    public new const short Id = 1995;

    public CharacterCharacteristicValue(short characteristicId, int total)
    {
        CharacteristicId = characteristicId;
        Total = total;
    }

    public CharacterCharacteristicValue()
    {
    }

    public override short TypeId => Id;

    public int Total { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(Total);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Total = reader.ReadInt();
    }
}