using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyStopFollowRequestMessage : AbstractPartyMessage
{
    public new const uint Id = 9834;

    public PartyStopFollowRequestMessage(uint partyId, ulong playerId)
    {
        PartyId = partyId;
        PlayerId = playerId;
    }

    public PartyStopFollowRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
    }
}