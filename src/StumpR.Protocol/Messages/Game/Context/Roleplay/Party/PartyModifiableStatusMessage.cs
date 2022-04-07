using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyModifiableStatusMessage : AbstractPartyMessage
{
    public new const uint Id = 4439;

    public PartyModifiableStatusMessage(uint partyId, bool enabled)
    {
        PartyId = partyId;
        Enabled = enabled;
    }

    public PartyModifiableStatusMessage()
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