using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyMemberRemoveMessage : AbstractPartyEventMessage
{
    public new const uint Id = 9078;

    public PartyMemberRemoveMessage(uint partyId, ulong leavingPlayerId)
    {
        PartyId = partyId;
        LeavingPlayerId = leavingPlayerId;
    }

    public PartyMemberRemoveMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong LeavingPlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(LeavingPlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LeavingPlayerId = reader.ReadVarULong();
    }
}