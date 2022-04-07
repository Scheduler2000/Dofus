using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ReloginTokenStatusMessage : Message
{
    public const uint Id = 3172;

    public ReloginTokenStatusMessage(bool validToken, IEnumerable<sbyte> ticket)
    {
        ValidToken = validToken;
        Ticket = ticket;
    }

    public ReloginTokenStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public bool ValidToken { get; set; }

    public IEnumerable<sbyte> Ticket { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(ValidToken);
        writer.WriteVarInt(Ticket.Count());
        foreach (sbyte objectToSend in Ticket) writer.WriteSByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ValidToken = reader.ReadBoolean();
        int ticketCount = reader.ReadVarInt();
        var ticket_ = new sbyte[ticketCount];
        for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++) ticket_[ticketIndex] = reader.ReadSByte();
        Ticket = ticket_;
    }
}