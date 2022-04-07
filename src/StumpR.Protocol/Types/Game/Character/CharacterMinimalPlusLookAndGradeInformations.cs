using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterMinimalPlusLookAndGradeInformations : CharacterMinimalPlusLookInformations
{
    public new const short Id = 7522;

    public CharacterMinimalPlusLookAndGradeInformations(ulong objectId,
        string name,
        ushort level,
        EntityLook entityLook,
        sbyte breed,
        uint grade)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Grade = grade;
    }

    public CharacterMinimalPlusLookAndGradeInformations()
    {
    }

    public override short TypeId => Id;

    public uint Grade { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Grade);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Grade = reader.ReadVarUInt();
    }
}