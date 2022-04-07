using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyCancelInvitationMessage : AbstractPartyMessage
{
    public new const uint Id = 7066;

    public PartyCancelInvitationMessage(uint partyId, ulong guestId)
    {
        PartyId = partyId;
        GuestId = guestId;
    }

    public PartyCancelInvitationMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong GuestId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(GuestId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        GuestId = reader.ReadVarULong();
    }
}