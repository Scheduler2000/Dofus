using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectoryEntryMessage : Message
{
    public const uint Id = 3827;

    public JobCrafterDirectoryEntryMessage(JobCrafterDirectoryEntryPlayerInfo playerInfo,
        IEnumerable<JobCrafterDirectoryEntryJobInfo> jobInfoList,
        EntityLook playerLook)
    {
        PlayerInfo = playerInfo;
        JobInfoList = jobInfoList;
        PlayerLook = playerLook;
    }

    public JobCrafterDirectoryEntryMessage()
    {
    }

    public override uint MessageId => Id;

    public JobCrafterDirectoryEntryPlayerInfo PlayerInfo { get; set; }

    public IEnumerable<JobCrafterDirectoryEntryJobInfo> JobInfoList { get; set; }

    public EntityLook PlayerLook { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        PlayerInfo.Serialize(writer);
        writer.WriteShort((short) JobInfoList.Count());
        foreach (JobCrafterDirectoryEntryJobInfo objectToSend in JobInfoList) objectToSend.Serialize(writer);
        PlayerLook.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerInfo = new JobCrafterDirectoryEntryPlayerInfo();
        PlayerInfo.Deserialize(reader);
        ushort jobInfoListCount = reader.ReadUShort();
        var jobInfoList_ = new JobCrafterDirectoryEntryJobInfo[jobInfoListCount];

        for (var jobInfoListIndex = 0; jobInfoListIndex < jobInfoListCount; jobInfoListIndex++)
        {
            var objectToAdd = new JobCrafterDirectoryEntryJobInfo();
            objectToAdd.Deserialize(reader);
            jobInfoList_[jobInfoListIndex] = objectToAdd;
        }
        JobInfoList = jobInfoList_;
        PlayerLook = new EntityLook();
        PlayerLook.Deserialize(reader);
    }
}