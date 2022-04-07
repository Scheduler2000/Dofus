using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportToBuddyCloseMessage : Message
{
    public const uint Id = 2991;

    public TeleportToBuddyCloseMessage(ushort dungeonId, ulong buddyId)
    {
        DungeonId = dungeonId;
        BuddyId = buddyId;
    }

    public TeleportToBuddyCloseMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public ulong BuddyId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteVarULong(BuddyId);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        BuddyId = reader.ReadVarULong();
    }
}