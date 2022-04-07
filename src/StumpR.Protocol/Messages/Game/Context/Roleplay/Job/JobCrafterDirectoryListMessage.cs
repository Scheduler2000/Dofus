using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectoryListMessage : Message
{
    public const uint Id = 7620;

    public JobCrafterDirectoryListMessage(IEnumerable<JobCrafterDirectoryListEntry> listEntries)
    {
        ListEntries = listEntries;
    }

    public JobCrafterDirectoryListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<JobCrafterDirectoryListEntry> ListEntries { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ListEntries.Count());
        foreach (JobCrafterDirectoryListEntry objectToSend in ListEntries) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort listEntriesCount = reader.ReadUShort();
        var listEntries_ = new JobCrafterDirectoryListEntry[listEntriesCount];

        for (var listEntriesIndex = 0; listEntriesIndex < listEntriesCount; listEntriesIndex++)
        {
            var objectToAdd = new JobCrafterDirectoryListEntry();
            objectToAdd.Deserialize(reader);
            listEntries_[listEntriesIndex] = objectToAdd;
        }
        ListEntries = listEntries_;
    }
}