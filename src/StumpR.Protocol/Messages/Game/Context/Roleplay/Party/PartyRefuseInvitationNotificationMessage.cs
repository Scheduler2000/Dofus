using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyRefuseInvitationNotificationMessage : AbstractPartyEventMessage
{
    public new const uint Id = 349;

    public PartyRefuseInvitationNotificationMessage(uint partyId, ulong guestId)
    {
        PartyId = partyId;
        GuestId = guestId;
    }

    public PartyRefuseInvitationNotificationMessage()
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