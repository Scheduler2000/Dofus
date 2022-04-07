using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyDeletedMessage : AbstractPartyMessage
{
    public new const uint Id = 1436;

    public PartyDeletedMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public PartyDeletedMessage()
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