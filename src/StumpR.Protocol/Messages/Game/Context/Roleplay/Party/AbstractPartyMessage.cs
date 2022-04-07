using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AbstractPartyMessage : Message
{
    public const uint Id = 3299;

    public AbstractPartyMessage(uint partyId)
    {
        PartyId = partyId;
    }

    public AbstractPartyMessage()
    {
    }

    public override uint MessageId => Id;

    public uint PartyId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(PartyId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PartyId = reader.ReadVarUInt();
    }
}