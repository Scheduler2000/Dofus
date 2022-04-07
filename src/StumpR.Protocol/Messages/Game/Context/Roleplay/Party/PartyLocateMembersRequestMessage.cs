using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyLocateMembersRequestMessage : AbstractPartyMessage
{
    public new const uint Id = 6564;

    public PartyLocateMembersRequestMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public PartyLocateMembersRequestMessage()
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