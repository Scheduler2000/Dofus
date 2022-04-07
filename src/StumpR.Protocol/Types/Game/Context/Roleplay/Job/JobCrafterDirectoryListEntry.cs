using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobCrafterDirectoryListEntry
{
    public const short Id = 3897;

    public JobCrafterDirectoryListEntry(JobCrafterDirectoryEntryPlayerInfo playerInfo, JobCrafterDirectoryEntryJobInfo jobInfo)
    {
        PlayerInfo = playerInfo;
        JobInfo = jobInfo;
    }

    public JobCrafterDirectoryListEntry()
    {
    }

    public virtual short TypeId => Id;

    public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }

    public JobCrafterDirectoryEntryJobInfo JobInfo { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        PlayerInfo.Serialize(writer);
        JobInfo.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
        PlayerInfo.Deserialize(reader);
        JobInfo = new JobCrafterDirectoryEntryJobInfo();
        JobInfo.Deserialize(reader);
    }
}