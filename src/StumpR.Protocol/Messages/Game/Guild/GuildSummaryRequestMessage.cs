using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildSummaryRequestMessage : PaginationRequestAbstractMessage
{
    public new const uint Id = 9211;

    public GuildSummaryRequestMessage(double offset,
        uint count,
        bool hideFullFilter,
        bool sortDescending,
        string nameFilter,
        IEnumerable<uint> criterionFilter,
        IEnumerable<uint> languagesFilter,
        IEnumerable<byte> recruitmentTypeFilter,
        short minLevelFilter,
        short maxLevelFilter,
        short minPlayerLevelFilter,
        short maxPlayerLevelFilter,
        uint minSuccessFilter,
        uint maxSuccessFilter,
        sbyte sortType)
    {
        Offset = offset;
        Count = count;
        HideFullFilter = hideFullFilter;
        SortDescending = sortDescending;
        NameFilter = nameFilter;
        CriterionFilter = criterionFilter;
        LanguagesFilter = languagesFilter;
        RecruitmentTypeFilter = recruitmentTypeFilter;
        MinLevelFilter = minLevelFilter;
        MaxLevelFilter = maxLevelFilter;
        MinPlayerLevelFilter = minPlayerLevelFilter;
        MaxPlayerLevelFilter = maxPlayerLevelFilter;
        MinSuccessFilter = minSuccessFilter;
        MaxSuccessFilter = maxSuccessFilter;
        SortType = sortType;
    }

    public GuildSummaryRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool HideFullFilter { get; set; }

    public bool SortDescending { get; set; }

    public string NameFilter { get; set; }

    public IEnumerable<uint> CriterionFilter { get; set; }

    public IEnumerable<uint> LanguagesFilter { get; set; }

    public IEnumerable<byte> RecruitmentTypeFilter { get; set; }

    public short MinLevelFilter { get; set; }

    public short MaxLevelFilter { get; set; }

    public short MinPlayerLevelFilter { get; set; }

    public short MaxPlayerLevelFilter { get; set; }

    public uint MinSuccessFilter { get; set; }

    public uint MaxSuccessFilter { get; set; }

    public sbyte SortType { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, HideFullFilter);
        flag = BooleanByteWrapper.SetFlag(flag, 1, SortDescending);
        writer.WriteByte(flag);
        writer.WriteUTF(NameFilter);
        writer.WriteShort((short) CriterionFilter.Count());
        foreach (uint objectToSend in CriterionFilter) writer.WriteVarUInt(objectToSend);
        writer.WriteShort((short) LanguagesFilter.Count());
        foreach (uint objectToSend in LanguagesFilter) writer.WriteVarUInt(objectToSend);
        writer.WriteShort((short) RecruitmentTypeFilter.Count());
        foreach (byte objectToSend in RecruitmentTypeFilter) writer.WriteByte(objectToSend);
        writer.WriteShort(MinLevelFilter);
        writer.WriteShort(MaxLevelFilter);
        writer.WriteShort(MinPlayerLevelFilter);
        writer.WriteShort(MaxPlayerLevelFilter);
        writer.WriteVarUInt(MinSuccessFilter);
        writer.WriteVarUInt(MaxSuccessFilter);
        writer.WriteSByte(SortType);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        byte flag = reader.ReadByte();
        HideFullFilter = BooleanByteWrapper.GetFlag(flag, 0);
        SortDescending = BooleanByteWrapper.GetFlag(flag, 1);
        NameFilter = reader.ReadUTF();
        ushort criterionFilterCount = reader.ReadUShort();
        var criterionFilter_ = new uint[criterionFilterCount];

        for (var criterionFilterIndex = 0; criterionFilterIndex < criterionFilterCount; criterionFilterIndex++)
            criterionFilter_[criterionFilterIndex] = reader.ReadVarUInt();
        CriterionFilter = criterionFilter_;
        ushort languagesFilterCount = reader.ReadUShort();
        var languagesFilter_ = new uint[languagesFilterCount];

        for (var languagesFilterIndex = 0; languagesFilterIndex < languagesFilterCount; languagesFilterIndex++)
            languagesFilter_[languagesFilterIndex] = reader.ReadVarUInt();
        LanguagesFilter = languagesFilter_;
        ushort recruitmentTypeFilterCount = reader.ReadUShort();
        var recruitmentTypeFilter_ = new byte[recruitmentTypeFilterCount];

        for (var recruitmentTypeFilterIndex = 0; recruitmentTypeFilterIndex < recruitmentTypeFilterCount; recruitmentTypeFilterIndex++)
            recruitmentTypeFilter_[recruitmentTypeFilterIndex] = reader.ReadByte();
        RecruitmentTypeFilter = recruitmentTypeFilter_;
        MinLevelFilter = reader.ReadShort();
        MaxLevelFilter = reader.ReadShort();
        MinPlayerLevelFilter = reader.ReadShort();
        MaxPlayerLevelFilter = reader.ReadShort();
        MinSuccessFilter = reader.ReadVarUInt();
        MaxSuccessFilter = reader.ReadVarUInt();
        SortType = reader.ReadSByte();
    }
}