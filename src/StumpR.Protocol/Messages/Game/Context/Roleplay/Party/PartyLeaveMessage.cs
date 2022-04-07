using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyLeaveMessage : AbstractPartyMessage
{
    public new const uint Id = 4001;

    public PartyLeaveMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public PartyLeaveMessage()
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