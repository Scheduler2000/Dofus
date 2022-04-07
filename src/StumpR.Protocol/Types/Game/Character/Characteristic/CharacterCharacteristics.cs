using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterCharacteristics
{
    public const short Id = 5368;

    public CharacterCharacteristics(IEnumerable<CharacterCharacteristic> characteristics)
    {
        Characteristics = characteristics;
    }

    public CharacterCharacteristics()
    {
    }

    public virtual short TypeId => Id;

    public IEnumerable<CharacterCharacteristic> Characteristics { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Characteristics.Count());

        foreach (CharacterCharacteristic objectToSend in Characteristics)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ushort characteristicsCount = reader.ReadUShort();
        var characteristics_ = new CharacterCharacteristic[characteristicsCount];

        for (var characteristicsIndex = 0; characteristicsIndex < characteristicsCount; characteristicsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<CharacterCharacteristic>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            characteristics_[characteristicsIndex] = objectToAdd;
        }
        Characteristics = characteristics_;
    }
}