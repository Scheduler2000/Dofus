using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
{
    public new const short Id = 4548;

    public CharacterMinimalGuildInformations(ulong objectId,
        string name,
        ushort level,
        EntityLook entityLook,
        sbyte breed,
        BasicGuildInformations guild)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Guild = guild;
    }

    public CharacterMinimalGuildInformations()
    {
    }

    public override short TypeId => Id;

    public BasicGuildInformations Guild { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Guild = new BasicGuildInformations();
        Guild.Deserialize(reader);
    }
}