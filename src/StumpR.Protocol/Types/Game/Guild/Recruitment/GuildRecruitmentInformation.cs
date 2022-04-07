using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildRecruitmentInformation
{
    public const short Id = 4584;

    public GuildRecruitmentInformation(bool minLevelFacultative,
        bool minSuccessFacultative,
        bool invalidatedByModeration,
        bool recruitmentAutoLocked,
        uint guildId,
        sbyte recruitmentType,
        string recruitmentTitle,
        string recruitmentText,
        IEnumerable<uint> selectedLanguages,
        IEnumerable<uint> selectedCriterion,
        short minLevel,
        uint minSuccess,
        string lastEditPlayerName,
        double lastEditDate)
    {
        MinLevelFacultative = minLevelFacultative;
        MinSuccessFacultative = minSuccessFacultative;
        InvalidatedByModeration = invalidatedByModeration;
        RecruitmentAutoLocked = recruitmentAutoLocked;
        GuildId = guildId;
        RecruitmentType = recruitmentType;
        RecruitmentTitle = recruitmentTitle;
        RecruitmentText = recruitmentText;
        SelectedLanguages = selectedLanguages;
        SelectedCriterion = selectedCriterion;
        MinLevel = minLevel;
        MinSuccess = minSuccess;
        LastEditPlayerName = lastEditPlayerName;
        LastEditDate = lastEditDate;
    }

    public GuildRecruitmentInformation()
    {
    }

    public virtual short TypeId => Id;

    public bool MinLevelFacultative { get; set; }

    public bool MinSuccessFacultative { get; set; }

    public bool InvalidatedByModeration { get; set; }

    public bool RecruitmentAutoLocked { get; set; }

    public uint GuildId { get; set; }

    public sbyte RecruitmentType { get; set; }

    public string RecruitmentTitle { get; set; }

    public string RecruitmentText { get; set; }

    public IEnumerable<uint> SelectedLanguages { get; set; }

    public IEnumerable<uint> SelectedCriterion { get; set; }

    public short MinLevel { get; set; }

    public uint MinSuccess { get; set; }

    public string LastEditPlayerName { get; set; }

    public double LastEditDate { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, MinLevelFacultative);
        flag = BooleanByteWrapper.SetFlag(flag, 1, MinSuccessFacultative);
        flag = BooleanByteWrapper.SetFlag(flag, 2, InvalidatedByModeration);
        flag = BooleanByteWrapper.SetFlag(flag, 3, RecruitmentAutoLocked);
        writer.WriteByte(flag);
        writer.WriteVarUInt(GuildId);
        writer.WriteSByte(RecruitmentType);
        writer.WriteUTF(RecruitmentTitle);
        writer.WriteUTF(RecruitmentText);
        writer.WriteShort((short) SelectedLanguages.Count());
        foreach (uint objectToSend in SelectedLanguages) writer.WriteVarUInt(objectToSend);
        writer.WriteShort((short) SelectedCriterion.Count());
        foreach (uint objectToSend in SelectedCriterion) writer.WriteVarUInt(objectToSend);
        writer.WriteShort(MinLevel);
        writer.WriteVarUInt(MinSuccess);
        writer.WriteUTF(LastEditPlayerName);
        writer.WriteDouble(LastEditDate);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        MinLevelFacultative = BooleanByteWrapper.GetFlag(flag, 0);
        MinSuccessFacultative = BooleanByteWrapper.GetFlag(flag, 1);
        InvalidatedByModeration = BooleanByteWrapper.GetFlag(flag, 2);
        RecruitmentAutoLocked = BooleanByteWrapper.GetFlag(flag, 3);
        GuildId = reader.ReadVarUInt();
        RecruitmentType = reader.ReadSByte();
        RecruitmentTitle = reader.ReadUTF();
        RecruitmentText = reader.ReadUTF();
        ushort selectedLanguagesCount = reader.ReadUShort();
        var selectedLanguages_ = new uint[selectedLanguagesCount];

        for (var selectedLanguagesIndex = 0; selectedLanguagesIndex < selectedLanguagesCount; selectedLanguagesIndex++)
            selectedLanguages_[selectedLanguagesIndex] = reader.ReadVarUInt();
        SelectedLanguages = selectedLanguages_;
        ushort selectedCriterionCount = reader.ReadUShort();
        var selectedCriterion_ = new uint[selectedCriterionCount];

        for (var selectedCriterionIndex = 0; selectedCriterionIndex < selectedCriterionCount; selectedCriterionIndex++)
            selectedCriterion_[selectedCriterionIndex] = reader.ReadVarUInt();
        SelectedCriterion = selectedCriterion_;
        MinLevel = reader.ReadShort();
        MinSuccess = reader.ReadVarUInt();
        LastEditPlayerName = reader.ReadUTF();
        LastEditDate = reader.ReadDouble();
    }
}