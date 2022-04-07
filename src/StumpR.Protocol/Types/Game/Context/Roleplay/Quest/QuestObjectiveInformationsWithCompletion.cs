using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class QuestObjectiveInformationsWithCompletion : QuestObjectiveInformations
{
    public new const short Id = 5115;

    public QuestObjectiveInformationsWithCompletion(ushort objectiveId,
        bool objectiveStatus,
        IEnumerable<string> dialogParams,
        ushort curCompletion,
        ushort maxCompletion)
    {
        ObjectiveId = objectiveId;
        ObjectiveStatus = objectiveStatus;
        DialogParams = dialogParams;
        CurCompletion = curCompletion;
        MaxCompletion = maxCompletion;
    }

    public QuestObjectiveInformationsWithCompletion()
    {
    }

    public override short TypeId => Id;

    public ushort CurCompletion { get; set; }

    public ushort MaxCompletion { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(CurCompletion);
        writer.WriteVarUShort(MaxCompletion);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CurCompletion = reader.ReadVarUShort();
        MaxCompletion = reader.ReadVarUShort();
    }
}