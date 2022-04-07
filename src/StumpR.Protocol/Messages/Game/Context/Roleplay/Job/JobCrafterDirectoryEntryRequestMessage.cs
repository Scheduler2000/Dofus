using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectoryEntryRequestMessage : Message
{
    public const uint Id = 3858;

    public JobCrafterDirectoryEntryRequestMessage(ulong playerId)
    {
        PlayerId = playerId;
    }

    public JobCrafterDirectoryEntryRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
    }
}