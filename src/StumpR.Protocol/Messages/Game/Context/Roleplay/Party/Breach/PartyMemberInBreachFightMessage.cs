using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage
{
    public new const uint Id = 9876;

    public PartyMemberInBreachFightMessage(uint partyId,
        sbyte reason,
        ulong memberId,
        int memberAccountId,
        string memberName,
        ushort fightId,
        short timeBeforeFightStart,
        uint floor,
        sbyte room)
    {
        PartyId = partyId;
        Reason = reason;
        MemberId = memberId;
        MemberAccountId = memberAccountId;
        MemberName = memberName;
        FightId = fightId;
        TimeBeforeFightStart = timeBeforeFightStart;
        Floor = floor;
        Room = room;
    }

    public PartyMemberInBreachFightMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Floor { get; set; }

    public sbyte Room { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Floor);
        writer.WriteSByte(Room);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Floor = reader.ReadVarUInt();
        Room = reader.ReadSByte();
    }
}