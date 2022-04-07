using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildSubmitApplicationMessage : Message
{
    public const uint Id = 9276;

    public GuildSubmitApplicationMessage(string applyText,
        uint guildId,
        uint timeSpent,
        string filterLanguage,
        string filterAmbiance,
        string filterPlaytime,
        string filterInterest,
        string filterMinMaxGuildLevel,
        string filterRecruitmentType,
        string filterMinMaxCharacterLevel,
        string filterMinMaxAchievement,
        string filterSearchName,
        string filterLastSort)
    {
        ApplyText = applyText;
        GuildId = guildId;
        TimeSpent = timeSpent;
        FilterLanguage = filterLanguage;
        FilterAmbiance = filterAmbiance;
        FilterPlaytime = filterPlaytime;
        FilterInterest = filterInterest;
        FilterMinMaxGuildLevel = filterMinMaxGuildLevel;
        FilterRecruitmentType = filterRecruitmentType;
        FilterMinMaxCharacterLevel = filterMinMaxCharacterLevel;
        FilterMinMaxAchievement = filterMinMaxAchievement;
        FilterSearchName = filterSearchName;
        FilterLastSort = filterLastSort;
    }

    public GuildSubmitApplicationMessage()
    {
    }

    public override uint MessageId => Id;

    public string ApplyText { get; set; }

    public uint GuildId { get; set; }

    public uint TimeSpent { get; set; }

    public string FilterLanguage { get; set; }

    public string FilterAmbiance { get; set; }

    public string FilterPlaytime { get; set; }

    public string FilterInterest { get; set; }

    public string FilterMinMaxGuildLevel { get; set; }

    public string FilterRecruitmentType { get; set; }

    public string FilterMinMaxCharacterLevel { get; set; }

    public string FilterMinMaxAchievement { get; set; }

    public string FilterSearchName { get; set; }

    public string FilterLastSort { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(ApplyText);
        writer.WriteVarUInt(GuildId);
        writer.WriteVarUInt(TimeSpent);
        writer.WriteUTF(FilterLanguage);
        writer.WriteUTF(FilterAmbiance);
        writer.WriteUTF(FilterPlaytime);
        writer.WriteUTF(FilterInterest);
        writer.WriteUTF(FilterMinMaxGuildLevel);
        writer.WriteUTF(FilterRecruitmentType);
        writer.WriteUTF(FilterMinMaxCharacterLevel);
        writer.WriteUTF(FilterMinMaxAchievement);
        writer.WriteUTF(FilterSearchName);
        writer.WriteUTF(FilterLastSort);
    }

    public override void Deserialize(IDataReader reader)
    {
        ApplyText = reader.ReadUTF();
        GuildId = reader.ReadVarUInt();
        TimeSpent = reader.ReadVarUInt();
        FilterLanguage = reader.ReadUTF();
        FilterAmbiance = reader.ReadUTF();
        FilterPlaytime = reader.ReadUTF();
        FilterInterest = reader.ReadUTF();
        FilterMinMaxGuildLevel = reader.ReadUTF();
        FilterRecruitmentType = reader.ReadUTF();
        FilterMinMaxCharacterLevel = reader.ReadUTF();
        FilterMinMaxAchievement = reader.ReadUTF();
        FilterSearchName = reader.ReadUTF();
        FilterLastSort = reader.ReadUTF();
    }
}