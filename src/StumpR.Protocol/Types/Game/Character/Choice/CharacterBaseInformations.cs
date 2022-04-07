using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterBaseInformations : CharacterMinimalPlusLookInformations
{
    public new const short Id = 8097;

    public CharacterBaseInformations(ulong objectId, string name, ushort level, EntityLook entityLook, sbyte breed, bool sex)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Sex = sex;
    }

    public CharacterBaseInformations()
    {
    }

    public override short TypeId => Id;

    public bool Sex { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Sex);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Sex = reader.ReadBoolean();
    }
}