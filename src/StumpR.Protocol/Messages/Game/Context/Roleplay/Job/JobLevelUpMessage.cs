using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobLevelUpMessage : Message
{
    public const uint Id = 8401;

    public JobLevelUpMessage(byte newLevel, JobDescription jobsDescription)
    {
        NewLevel = newLevel;
        JobsDescription = jobsDescription;
    }

    public JobLevelUpMessage()
    {
    }

    public override uint MessageId => Id;

    public byte NewLevel { get; set; }

    public JobDescription JobsDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteByte(NewLevel);
        JobsDescription.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        NewLevel = reader.ReadByte();
        JobsDescription = new JobDescription();
        JobsDescription.Deserialize(reader);
    }
}