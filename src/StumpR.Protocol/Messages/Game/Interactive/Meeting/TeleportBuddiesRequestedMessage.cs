using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportBuddiesRequestedMessage : Message
{
    public const uint Id = 9435;

    public TeleportBuddiesRequestedMessage(ushort dungeonId, ulong inviterId, IEnumerable<ulong> invalidBuddiesIds)
    {
        DungeonId = dungeonId;
        InviterId = inviterId;
        InvalidBuddiesIds = invalidBuddiesIds;
    }

    public TeleportBuddiesRequestedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public ulong InviterId { get; set; }

    public IEnumerable<ulong> InvalidBuddiesIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(DungeonId);
        writer.WriteVarULong(InviterId);
        writer.WriteShort((short) InvalidBuddiesIds.Count());
        foreach (ulong objectToSend in InvalidBuddiesIds) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        DungeonId = reader.ReadVarUShort();
        InviterId = reader.ReadVarULong();
        ushort invalidBuddiesIdsCount = reader.ReadUShort();
        var invalidBuddiesIds_ = new ulong[invalidBuddiesIdsCount];

        for (var invalidBuddiesIdsIndex = 0; invalidBuddiesIdsIndex < invalidBuddiesIdsCount; invalidBuddiesIdsIndex++)
            invalidBuddiesIds_[invalidBuddiesIdsIndex] = reader.ReadVarULong();
        InvalidBuddiesIds = invalidBuddiesIds_;
    }
}