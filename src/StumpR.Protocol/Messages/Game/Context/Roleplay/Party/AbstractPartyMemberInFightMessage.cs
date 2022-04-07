using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AbstractPartyMemberInFightMessage : AbstractPartyMessage
{
    public new const uint Id = 1888;

    public AbstractPartyMemberInFightMessage(uint partyId,
        sbyte reason,
        ulong memberId,
        int memberAccountId,
        string memberName,
        ushort fightId,
        short timeBeforeFightStart)
    {
        PartyId = partyId;
        Reason = reason;
        MemberId = memberId;
        MemberAccountId = memberAccountId;
        MemberName = memberName;
        FightId = fightId;
        TimeBeforeFightStart = timeBeforeFightStart;
    }

    public AbstractPartyMemberInFightMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public ulong MemberId { get; set; }

    public int MemberAccountId { get; set; }

    public string MemberName { get; set; }

    public ushort FightId { get; set; }

    public short TimeBeforeFightStart { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(Reason);
        writer.WriteVarULong(MemberId);
        writer.WriteInt(MemberAccountId);
        writer.WriteUTF(MemberName);
        writer.WriteVarUShort(FightId);
        writer.WriteVarShort(TimeBeforeFightStart);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Reason = reader.ReadSByte();
        MemberId = reader.ReadVarULong();
        MemberAccountId = reader.ReadInt();
        MemberName = reader.ReadUTF();
        FightId = reader.ReadVarUShort();
        TimeBeforeFightStart = reader.ReadVarShort();
    }
}