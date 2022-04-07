using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
{
    public new const short Id = 4354;

    public CharacterMinimalAllianceInformations(ulong objectId,
        string name,
        ushort level,
        EntityLook entityLook,
        sbyte breed,
        BasicGuildInformations guild,
        BasicAllianceInformations alliance)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Guild = guild;
        Alliance = alliance;
    }

    public CharacterMinimalAllianceInformations()
    {
    }

    public override short TypeId => Id;

    public BasicAllianceInformations Alliance { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Alliance.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Alliance = new BasicAllianceInformations();
        Alliance.Deserialize(reader);
    }
}