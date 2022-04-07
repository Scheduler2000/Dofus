using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyNameUpdateMessage : AbstractPartyMessage
{
    public new const uint Id = 4910;

    public PartyNameUpdateMessage(uint partyId, string partyName)
    {
        PartyId = partyId;
        PartyName = partyName;
    }

    public PartyNameUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public string PartyName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(PartyName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PartyName = reader.ReadUTF();
    }
}