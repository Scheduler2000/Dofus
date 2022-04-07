using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportToBuddyOfferMessage : Message
{
    public const uint Id = 4009;

    public TeleportToBuddyOfferMessage(ushort dungeonId, ulong buddyId, uint timeLeft)
    {
        DungeonId = dungeonId;
        BuddyId = buddyId;
        TimeLeft = timeLeft;
    }

    public TeleportToBuddyOfferMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public ulong BuddyId { get; set; }

    public uint TimeLeft { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteVarULong(BuddyId);
        writer.WriteVarUInt(TimeLeft);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        BuddyId = reader.ReadVarULong();
        TimeLeft = reader.ReadVarUInt();
    }
}