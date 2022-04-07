using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyLeaderUpdateMessage : AbstractPartyEventMessage
{
    public new const uint Id = 4003;

    public PartyLeaderUpdateMessage(uint partyId, ulong partyLeaderId)
    {
        PartyId = partyId;
        PartyLeaderId = partyLeaderId;
    }

    public PartyLeaderUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PartyLeaderId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PartyLeaderId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PartyLeaderId = reader.ReadVarULong();
    }
}