using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
{
    public new const uint Id = 4755;

    public PartyFollowThisMemberRequestMessage(uint partyId, ulong playerId, bool enabled)
    {
        PartyId = partyId;
        PlayerId = playerId;
        Enabled = enabled;
    }

    public PartyFollowThisMemberRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Enabled { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Enabled);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Enabled = reader.ReadBoolean();
    }
}