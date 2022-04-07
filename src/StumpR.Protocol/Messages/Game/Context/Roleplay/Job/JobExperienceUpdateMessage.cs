using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobExperienceUpdateMessage : Message
{
    public const uint Id = 3940;

    public JobExperienceUpdateMessage(JobExperience experiencesUpdate)
    {
        ExperiencesUpdate = experiencesUpdate;
    }

    public JobExperienceUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public JobExperience ExperiencesUpdate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        ExperiencesUpdate.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ExperiencesUpdate = new JobExperience();
        ExperiencesUpdate.Deserialize(reader);
    }
}