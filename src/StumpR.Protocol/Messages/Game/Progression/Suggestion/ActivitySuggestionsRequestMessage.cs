using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ActivitySuggestionsRequestMessage : Message
{
    public const uint Id = 2540;

    public ActivitySuggestionsRequestMessage(ushort minLevel, ushort maxLevel, ushort areaId, ushort activityCategoryId, ushort nbCards)
    {
        MinLevel = minLevel;
        MaxLevel = maxLevel;
        AreaId = areaId;
        ActivityCategoryId = activityCategoryId;
        NbCards = nbCards;
    }

    public ActivitySuggestionsRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort MinLevel { get; set; }

    public ushort MaxLevel { get; set; }

    public ushort AreaId { get; set; }

    public ushort ActivityCategoryId { get; set; }

    public ushort NbCards { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(MinLevel);
        writer.WriteVarUShort(MaxLevel);
        writer.WriteVarUShort(AreaId);
        writer.WriteVarUShort(ActivityCategoryId);
        writer.WriteUShort(NbCards);
    }

    public override void Deserialize(IDataReader reader)
    {
        MinLevel = reader.ReadVarUShort();
        MaxLevel = reader.ReadVarUShort();
        AreaId = reader.ReadVarUShort();
        ActivityCategoryId = reader.ReadVarUShort();
        NbCards = reader.ReadUShort();
    }
}