using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class QuestActiveDetailedInformations : QuestActiveInformations
{
    public new const short Id = 2409;

    public QuestActiveDetailedInformations(ushort questId, ushort stepId, IEnumerable<QuestObjectiveInformations> objectives)
    {
        QuestId = questId;
        StepId = stepId;
        Objectives = objectives;
    }

    public QuestActiveDetailedInformations()
    {
    }

    public override short TypeId => Id;

    public ushort StepId { get; set; }

    public IEnumerable<QuestObjectiveInformations> Objectives { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(StepId);
        writer.WriteShort((short) Objectives.Count());

        foreach (QuestObjectiveInformations objectToSend in Objectives)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        StepId = reader.ReadVarUShort();
        ushort objectivesCount = reader.ReadUShort();
        var objectives_ = new QuestObjectiveInformations[objectivesCount];

        for (var objectivesIndex = 0; objectivesIndex < objectivesCount; objectivesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<QuestObjectiveInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            objectives_[objectivesIndex] = objectToAdd;
        }
        Objectives = objectives_;
    }
}