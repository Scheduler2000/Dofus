using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class QuestObjectiveInformations
{
    public const short Id = 4677;

    public QuestObjectiveInformations(ushort objectiveId, bool objectiveStatus, IEnumerable<string> dialogParams)
    {
        ObjectiveId = objectiveId;
        ObjectiveStatus = objectiveStatus;
        DialogParams = dialogParams;
    }

    public QuestObjectiveInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectiveId { get; set; }

    public bool ObjectiveStatus { get; set; }

    public IEnumerable<string> DialogParams { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectiveId);
        writer.WriteBoolean(ObjectiveStatus);
        writer.WriteShort((short) DialogParams.Count());
        foreach (string objectToSend in DialogParams) writer.WriteUTF(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectiveId = reader.ReadVarUShort();
        ObjectiveStatus = reader.ReadBoolean();
        ushort dialogParamsCount = reader.ReadUShort();
        var dialogParams_ = new string[dialogParamsCount];

        for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
            dialogParams_[dialogParamsIndex] = reader.ReadUTF();
        DialogParams = dialogParams_;
    }
}