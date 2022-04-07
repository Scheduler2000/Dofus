using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportToBuddyAnswerMessage : Message
{
    public const uint Id = 5687;

    public TeleportToBuddyAnswerMessage(ushort dungeonId, ulong buddyId, bool accept)
    {
        DungeonId = dungeonId;
        BuddyId = buddyId;
        Accept = accept;
    }

    public TeleportToBuddyAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public ulong BuddyId { get; set; }

    public bool Accept { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteVarULong(BuddyId);
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        BuddyId = reader.ReadVarULong();
        Accept = reader.ReadBoolean();
    }
}