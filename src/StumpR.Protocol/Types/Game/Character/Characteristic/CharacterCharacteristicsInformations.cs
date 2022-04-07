using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class CharacterCharacteristicsInformations
{
    public const short Id = 1918;

    public CharacterCharacteristicsInformations(ulong experience,
        ulong experienceLevelFloor,
        ulong experienceNextLevelFloor,
        ulong experienceBonusLimit,
        ulong kamas,
        ActorExtendedAlignmentInformations alignmentInfos,
        ushort criticalHitWeapon,
        IEnumerable<CharacterCharacteristic> characteristics,
        IEnumerable<CharacterSpellModification> spellModifications,
        int probationTime)
    {
        Experience = experience;
        ExperienceLevelFloor = experienceLevelFloor;
        ExperienceNextLevelFloor = experienceNextLevelFloor;
        ExperienceBonusLimit = experienceBonusLimit;
        Kamas = kamas;
        AlignmentInfos = alignmentInfos;
        CriticalHitWeapon = criticalHitWeapon;
        Characteristics = characteristics;
        SpellModifications = spellModifications;
        ProbationTime = probationTime;
    }

    public CharacterCharacteristicsInformations()
    {
    }

    public virtual short TypeId => Id;

    public ulong Experience { get; set; }

    public ulong ExperienceLevelFloor { get; set; }

    public ulong ExperienceNextLevelFloor { get; set; }

    public ulong ExperienceBonusLimit { get; set; }

    public ulong Kamas { get; set; }

    public ActorExtendedAlignmentInformations AlignmentInfos { get; set; }

    public ushort CriticalHitWeapon { get; set; }

    public IEnumerable<CharacterCharacteristic> Characteristics { get; set; }

    public IEnumerable<CharacterSpellModification> SpellModifications { get; set; }

    public int ProbationTime { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Experience);
        writer.WriteVarULong(ExperienceLevelFloor);
        writer.WriteVarULong(ExperienceNextLevelFloor);
        writer.WriteVarULong(ExperienceBonusLimit);
        writer.WriteVarULong(Kamas);
        AlignmentInfos.Serialize(writer);
        writer.WriteVarUShort(CriticalHitWeapon);
        writer.WriteShort((short) Characteristics.Count());

        foreach (CharacterCharacteristic objectToSend in Characteristics)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) SpellModifications.Count());
        foreach (CharacterSpellModification objectToSend in SpellModifications) objectToSend.Serialize(writer);
        writer.WriteInt(ProbationTime);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Experience = reader.ReadVarULong();
        ExperienceLevelFloor = reader.ReadVarULong();
        ExperienceNextLevelFloor = reader.ReadVarULong();
        ExperienceBonusLimit = reader.ReadVarULong();
        Kamas = reader.ReadVarULong();
        AlignmentInfos = new ActorExtendedAlignmentInformations();
        AlignmentInfos.Deserialize(reader);
        CriticalHitWeapon = reader.ReadVarUShort();
        ushort characteristicsCount = reader.ReadUShort();
        var characteristics_ = new CharacterCharacteristic[characteristicsCount];

        for (var characteristicsIndex = 0; characteristicsIndex < characteristicsCount; characteristicsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<CharacterCharacteristic>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            characteristics_[characteristicsIndex] = objectToAdd;
        }
        Characteristics = characteristics_;
        ushort spellModificationsCount = reader.ReadUShort();
        var spellModifications_ = new CharacterSpellModification[spellModificationsCount];

        for (var spellModificationsIndex = 0; spellModificationsIndex < spellModificationsCount; spellModificationsIndex++)
        {
            var objectToAdd = new CharacterSpellModification();
            objectToAdd.Deserialize(reader);
            spellModifications_[spellModificationsIndex] = objectToAdd;
        }
        SpellModifications = spellModifications_;
        ProbationTime = reader.ReadInt();
    }
}