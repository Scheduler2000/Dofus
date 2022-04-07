using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectoryAddMessage : Message
{
    public const uint Id = 1829;

    public JobCrafterDirectoryAddMessage(JobCrafterDirectoryListEntry listEntry)
    {
        ListEntry = listEntry;
    }

    public JobCrafterDirectoryAddMessage()
    {
    }

    public override uint MessageId => Id;

    public JobCrafterDirectoryListEntry ListEntry { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        ListEntry.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ListEntry = new JobCrafterDirectoryListEntry();
        ListEntry.Deserialize(reader);
    }
}