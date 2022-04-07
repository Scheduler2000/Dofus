using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations
{
    public new const short Id = 7850;

    public CharacterHardcoreOrEpicInformations(ulong objectId,
        string name,
        ushort level,
        EntityLook entityLook,
        sbyte breed,
        bool sex,
        sbyte deathState,
        ushort deathCount,
        ushort deathMaxLevel)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Sex = sex;
        DeathState = deathState;
        DeathCount = deathCount;
        DeathMaxLevel = deathMaxLevel;
    }

    public CharacterHardcoreOrEpicInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte DeathState { get; set; }

    public ushort DeathCount { get; set; }

    public ushort DeathMaxLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(DeathState);
        writer.WriteVarUShort(DeathCount);
        writer.WriteVarUShort(DeathMaxLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        DeathState = reader.ReadSByte();
        DeathCount = reader.ReadVarUShort();
        DeathMaxLevel = reader.ReadVarUShort();
    }
}