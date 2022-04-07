using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobCrafterDirectorySettings
{
    public const short Id = 6079;

    public JobCrafterDirectorySettings(sbyte jobId, byte minLevel, bool free)
    {
        JobId = jobId;
        MinLevel = minLevel;
        Free = free;
    }

    public JobCrafterDirectorySettings()
    {
    }

    public virtual short TypeId => Id;

    public sbyte JobId { get; set; }

    public byte MinLevel { get; set; }

    public bool Free { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(JobId);
        writer.WriteByte(MinLevel);
        writer.WriteBoolean(Free);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        JobId = reader.ReadSByte();
        MinLevel = reader.ReadByte();
        Free = reader.ReadBoolean();
    }
}