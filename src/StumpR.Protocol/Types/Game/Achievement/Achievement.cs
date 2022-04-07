using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class Achievement
{
    public const short Id = 8621;

    public Achievement(ushort objectId,
        IEnumerable<AchievementObjective> finishedObjective,
        IEnumerable<AchievementStartedObjective> startedObjectives)
    {
        ObjectId = objectId;
        FinishedObjective = finishedObjective;
        StartedObjectives = startedObjectives;
    }

    public Achievement()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectId { get; set; }

    public IEnumerable<AchievementObjective> FinishedObjective { get; set; }

    public IEnumerable<AchievementStartedObjective> StartedObjectives { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteShort((short) FinishedObjective.Count());
        foreach (AchievementObjective objectToSend in FinishedObjective) objectToSend.Serialize(writer);
        writer.WriteShort((short) StartedObjectives.Count());
        foreach (AchievementStartedObjective objectToSend in StartedObjectives) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        ushort finishedObjectiveCount = reader.ReadUShort();
        var finishedObjective_ = new AchievementObjective[finishedObjectiveCount];

        for (var finishedObjectiveIndex = 0; finishedObjectiveIndex < finishedObjectiveCount; finishedObjectiveIndex++)
        {
            var objectToAdd = new AchievementObjective();
            objectToAdd.Deserialize(reader);
            finishedObjective_[finishedObjectiveIndex] = objectToAdd;
        }
        FinishedObjective = finishedObjective_;
        ushort startedObjectivesCount = reader.ReadUShort();
        var startedObjectives_ = new AchievementStartedObjective[startedObjectivesCount];

        for (var startedObjectivesIndex = 0; startedObjectivesIndex < startedObjectivesCount; startedObjectivesIndex++)
        {
            var objectToAdd = new AchievementStartedObjective();
            objectToAdd.Deserialize(reader);
            startedObjectives_[startedObjectivesIndex] = objectToAdd;
        }
        StartedObjectives = startedObjectives_;
    }
}