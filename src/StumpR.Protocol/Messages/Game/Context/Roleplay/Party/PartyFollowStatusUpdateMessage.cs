using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyFollowStatusUpdateMessage : AbstractPartyMessage
{
    public new const uint Id = 4806;

    public PartyFollowStatusUpdateMessage(uint partyId, bool success, bool isFollowed, ulong followedId)
    {
        PartyId = partyId;
        Success = success;
        IsFollowed = isFollowed;
        FollowedId = followedId;
    }

    public PartyFollowStatusUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Success { get; set; }

    public bool IsFollowed { get; set; }

    public ulong FollowedId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Success);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsFollowed);
        writer.WriteByte(flag);
        writer.WriteVarULong(FollowedId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        byte flag = reader.ReadByte();
        Success = BooleanByteWrapper.GetFlag(flag, 0);
        IsFollowed = BooleanByteWrapper.GetFlag(flag, 1);
        FollowedId = reader.ReadVarULong();
    }
}