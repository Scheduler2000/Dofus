using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyNewGuestMessage : AbstractPartyEventMessage
{
    public new const uint Id = 1263;

    public PartyNewGuestMessage(uint partyId, PartyGuestInformations guest)
    {
        PartyId = partyId;
        Guest = guest;
    }

    public PartyNewGuestMessage()
    {
    }

    public override uint MessageId => Id;

    public PartyGuestInformations Guest { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Guest.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Guest = new PartyGuestInformations();
        Guest.Deserialize(reader);
    }
}