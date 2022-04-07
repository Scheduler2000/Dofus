using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobCrafterDirectoryEntryJobInfo
{
    public const short Id = 5220;

    public JobCrafterDirectoryEntryJobInfo(sbyte jobId, byte jobLevel, bool free, byte minLevel)
    {
        JobId = jobId;
        JobLevel = jobLevel;
        Free = free;
        MinLevel = minLevel;
    }

    public JobCrafterDirectoryEntryJobInfo()
    {
    }

    public virtual short TypeId => Id;

    public sbyte JobId { get; set; }

    public byte JobLevel { get; set; }

    public bool Free { get; set; }

    public byte MinLevel { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(JobId);
        writer.WriteByte(JobLevel);
        writer.WriteBoolean(Free);
        writer.WriteByte(MinLevel);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        JobId = reader.ReadSByte();
        JobLevel = reader.ReadByte();
        Free = reader.ReadBoolean();
        MinLevel = reader.ReadByte();
    }
}