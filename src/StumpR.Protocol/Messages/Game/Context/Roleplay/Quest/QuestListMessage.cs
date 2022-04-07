using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class QuestListMessage : Message
{
    public const uint Id = 5774;

    public QuestListMessage(IEnumerable<ushort> finishedQuestsIds,
        IEnumerable<ushort> finishedQuestsCounts,
        IEnumerable<QuestActiveInformations> activeQuests,
        IEnumerable<ushort> reinitDoneQuestsIds)
    {
        FinishedQuestsIds = finishedQuestsIds;
        FinishedQuestsCounts = finishedQuestsCounts;
        ActiveQuests = activeQuests;
        ReinitDoneQuestsIds = reinitDoneQuestsIds;
    }

    public QuestListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> FinishedQuestsIds { get; set; }

    public IEnumerable<ushort> FinishedQuestsCounts { get; set; }

    public IEnumerable<QuestActiveInformations> ActiveQuests { get; set; }

    public IEnumerable<ushort> ReinitDoneQuestsIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) FinishedQuestsIds.Count());
        foreach (ushort objectToSend in FinishedQuestsIds) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) FinishedQuestsCounts.Count());
        foreach (ushort objectToSend in FinishedQuestsCounts) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) ActiveQuests.Count());

        foreach (QuestActiveInformations objectToSend in ActiveQuests)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) ReinitDoneQuestsIds.Count());
        foreach (ushort objectToSend in ReinitDoneQuestsIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort finishedQuestsIdsCount = reader.ReadUShort();
        var finishedQuestsIds_ = new ushort[finishedQuestsIdsCount];

        for (var finishedQuestsIdsIndex = 0; finishedQuestsIdsIndex < finishedQuestsIdsCount; finishedQuestsIdsIndex++)
            finishedQuestsIds_[finishedQuestsIdsIndex] = reader.ReadVarUShort();
        FinishedQuestsIds = finishedQuestsIds_;
        ushort finishedQuestsCountsCount = reader.ReadUShort();
        var finishedQuestsCounts_ = new ushort[finishedQuestsCountsCount];

        for (var finishedQuestsCountsIndex = 0; finishedQuestsCountsIndex < finishedQuestsCountsCount; finishedQuestsCountsIndex++)
            finishedQuestsCounts_[finishedQuestsCountsIndex] = reader.ReadVarUShort();
        FinishedQuestsCounts = finishedQuestsCounts_;
        ushort activeQuestsCount = reader.ReadUShort();
        var activeQuests_ = new QuestActiveInformations[activeQuestsCount];

        for (var activeQuestsIndex = 0; activeQuestsIndex < activeQuestsCount; activeQuestsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<QuestActiveInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            activeQuests_[activeQuestsIndex] = objectToAdd;
        }
        ActiveQuests = activeQuests_;
        ushort reinitDoneQuestsIdsCount = reader.ReadUShort();
        var reinitDoneQuestsIds_ = new ushort[reinitDoneQuestsIdsCount];

        for (var reinitDoneQuestsIdsIndex = 0; reinitDoneQuestsIdsIndex < reinitDoneQuestsIdsCount; reinitDoneQuestsIdsIndex++)
            reinitDoneQuestsIds_[reinitDoneQuestsIdsIndex] = reader.ReadVarUShort();
        ReinitDoneQuestsIds = reinitDoneQuestsIds_;
    }
}