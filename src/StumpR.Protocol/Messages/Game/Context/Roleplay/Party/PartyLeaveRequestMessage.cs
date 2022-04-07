using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyLeaveRequestMessage : AbstractPartyMessage
{
    public new const uint Id = 1964;

    public PartyLeaveRequestMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public PartyLeaveRequestMessage()
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