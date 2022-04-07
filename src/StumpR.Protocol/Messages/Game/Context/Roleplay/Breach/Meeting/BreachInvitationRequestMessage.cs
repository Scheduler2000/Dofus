using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachInvitationRequestMessage : Message
{
    public const uint Id = 7544;

    public BreachInvitationRequestMessage(IEnumerable<ulong> guests)
    {
        Guests = guests;
    }

    public BreachInvitationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ulong> Guests { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Guests.Count());
        foreach (ulong objectToSend in Guests) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort guestsCount = reader.ReadUShort();
        var guests_ = new ulong[guestsCount];
        for (var guestsIndex = 0; guestsIndex < guestsCount; guestsIndex++) guests_[guestsIndex] = reader.ReadVarULong();
        Guests = guests_;
    }
}