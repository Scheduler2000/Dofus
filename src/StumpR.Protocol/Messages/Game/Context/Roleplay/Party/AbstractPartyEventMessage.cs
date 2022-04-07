using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AbstractPartyEventMessage : AbstractPartyMessage
{
    public new const uint Id = 2544;

    public AbstractPartyEventMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public AbstractPartyEventMessage()
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