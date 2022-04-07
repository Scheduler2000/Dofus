using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobExperienceMultiUpdateMessage : Message
{
    public const uint Id = 4771;

    public JobExperienceMultiUpdateMessage(IEnumerable<JobExperience> experiencesUpdate)
    {
        ExperiencesUpdate = experiencesUpdate;
    }

    public JobExperienceMultiUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<JobExperience> ExperiencesUpdate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ExperiencesUpdate.Count());
        foreach (JobExperience objectToSend in ExperiencesUpdate) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort experiencesUpdateCount = reader.ReadUShort();
        var experiencesUpdate_ = new JobExperience[experiencesUpdateCount];

        for (var experiencesUpdateIndex = 0; experiencesUpdateIndex < experiencesUpdateCount; experiencesUpdateIndex++)
        {
            var objectToAdd = new JobExperience();
            objectToAdd.Deserialize(reader);
            experiencesUpdate_[experiencesUpdateIndex] = objectToAdd;
        }
        ExperiencesUpdate = experiencesUpdate_;
    }
}