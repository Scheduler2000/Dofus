using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ActivitySuggestionsMessage : Message
{
    public const uint Id = 5931;

    public ActivitySuggestionsMessage(IEnumerable<ushort> lockedActivitiesIds, IEnumerable<ushort> unlockedActivitiesIds)
    {
        LockedActivitiesIds = lockedActivitiesIds;
        UnlockedActivitiesIds = unlockedActivitiesIds;
    }

    public ActivitySuggestionsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> LockedActivitiesIds { get; set; }

    public IEnumerable<ushort> UnlockedActivitiesIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) LockedActivitiesIds.Count());
        foreach (ushort objectToSend in LockedActivitiesIds) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) UnlockedActivitiesIds.Count());
        foreach (ushort objectToSend in UnlockedActivitiesIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort lockedActivitiesIdsCount = reader.ReadUShort();
        var lockedActivitiesIds_ = new ushort[lockedActivitiesIdsCount];

        for (var lockedActivitiesIdsIndex = 0; lockedActivitiesIdsIndex < lockedActivitiesIdsCount; lockedActivitiesIdsIndex++)
            lockedActivitiesIds_[lockedActivitiesIdsIndex] = reader.ReadVarUShort();
        LockedActivitiesIds = lockedActivitiesIds_;
        ushort unlockedActivitiesIdsCount = reader.ReadUShort();
        var unlockedActivitiesIds_ = new ushort[unlockedActivitiesIdsCount];

        for (var unlockedActivitiesIdsIndex = 0; unlockedActivitiesIdsIndex < unlockedActivitiesIdsCount; unlockedActivitiesIdsIndex++)
            unlockedActivitiesIds_[unlockedActivitiesIdsIndex] = reader.ReadVarUShort();
        UnlockedActivitiesIds = unlockedActivitiesIds_;
    }
}