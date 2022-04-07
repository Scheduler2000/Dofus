using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobDescriptionMessage : Message
{
    public const uint Id = 8838;

    public JobDescriptionMessage(IEnumerable<JobDescription> jobsDescription)
    {
        JobsDescription = jobsDescription;
    }

    public JobDescriptionMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<JobDescription> JobsDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) JobsDescription.Count());
        foreach (JobDescription objectToSend in JobsDescription) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort jobsDescriptionCount = reader.ReadUShort();
        var jobsDescription_ = new JobDescription[jobsDescriptionCount];

        for (var jobsDescriptionIndex = 0; jobsDescriptionIndex < jobsDescriptionCount; jobsDescriptionIndex++)
        {
            var objectToAdd = new JobDescription();
            objectToAdd.Deserialize(reader);
            jobsDescription_[jobsDescriptionIndex] = objectToAdd;
        }
        JobsDescription = jobsDescription_;
    }
}