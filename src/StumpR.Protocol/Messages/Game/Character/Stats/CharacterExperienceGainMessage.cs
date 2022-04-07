using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterExperienceGainMessage : Message
{
    public const uint Id = 4524;

    public CharacterExperienceGainMessage(ulong experienceCharacter,
        ulong experienceMount,
        ulong experienceGuild,
        ulong experienceIncarnation)
    {
        ExperienceCharacter = experienceCharacter;
        ExperienceMount = experienceMount;
        ExperienceGuild = experienceGuild;
        ExperienceIncarnation = experienceIncarnation;
    }

    public CharacterExperienceGainMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ExperienceCharacter { get; set; }

    public ulong ExperienceMount { get; set; }

    public ulong ExperienceGuild { get; set; }

    public ulong ExperienceIncarnation { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ExperienceCharacter);
        writer.WriteVarULong(ExperienceMount);
        writer.WriteVarULong(ExperienceGuild);
        writer.WriteVarULong(ExperienceIncarnation);
    }

    public override void Deserialize(IDataReader reader)
    {
        ExperienceCharacter = reader.ReadVarULong();
        ExperienceMount = reader.ReadVarULong();
        ExperienceGuild = reader.ReadVarULong();
        ExperienceIncarnation = reader.ReadVarULong();
    }
}