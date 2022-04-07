using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WatchQuestListMessage : QuestListMessage
{
    public new const uint Id = 9128;

    public WatchQuestListMessage(IEnumerable<ushort> finishedQuestsIds,
        IEnumerable<ushort> finishedQuestsCounts,
        IEnumerable<QuestActiveInformations> activeQuests,
        IEnumerable<ushort> reinitDoneQuestsIds,
        ulong playerId)
    {
        FinishedQuestsIds = finishedQuestsIds;
        FinishedQuestsCounts = finishedQuestsCounts;
        ActiveQuests = activeQuests;
        ReinitDoneQuestsIds = reinitDoneQuestsIds;
        PlayerId = playerId;
    }

    public WatchQuestListMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
    }
}