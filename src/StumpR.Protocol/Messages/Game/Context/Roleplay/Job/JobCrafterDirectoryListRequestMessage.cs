using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectoryListRequestMessage : Message
{
    public const uint Id = 5786;

    public JobCrafterDirectoryListRequestMessage(sbyte jobId)
    {
        JobId = jobId;
    }

    public JobCrafterDirectoryListRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte JobId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(JobId);
    }

    public override void Deserialize(IDataReader reader)
    {
        JobId = reader.ReadSByte();
    }
}