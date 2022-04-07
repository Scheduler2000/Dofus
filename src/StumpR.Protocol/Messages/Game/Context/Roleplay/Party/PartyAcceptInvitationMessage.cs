using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyAcceptInvitationMessage : AbstractPartyMessage
{
    public new const uint Id = 866;

    public PartyAcceptInvitationMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public PartyAcceptInvitationMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}