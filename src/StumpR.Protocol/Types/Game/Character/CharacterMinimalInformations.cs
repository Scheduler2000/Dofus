using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterMinimalInformations : CharacterBasicMinimalInformations
{
    public new const short Id = 6674;

    public CharacterMinimalInformations(ulong objectId, string name, ushort level)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
    }

    public CharacterMinimalInformations()
    {
    }

    public override short TypeId => Id;

    public ushort Level { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Level);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadVarUShort();
    }
}