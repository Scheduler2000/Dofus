using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyNameSetErrorMessage : AbstractPartyMessage
{
    public new const uint Id = 9899;

    public PartyNameSetErrorMessage(uint partyId, sbyte result)
    {
        PartyId = partyId;
        Result = result;
    }

    public PartyNameSetErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Result { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(Result);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Result = reader.ReadSByte();
    }
}