using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaSwitchToGameServerMessage : Message
{
    public const uint Id = 651;

    public GameRolePlayArenaSwitchToGameServerMessage(bool validToken, IEnumerable<sbyte> ticket, short homeServerId)
    {
        ValidToken = validToken;
        Ticket = ticket;
        HomeServerId = homeServerId;
    }

    public GameRolePlayArenaSwitchToGameServerMessage()
    {
    }

    public override uint MessageId => Id;

    public bool ValidToken { get; set; }

    public IEnumerable<sbyte> Ticket { get; set; }

    public short HomeServerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(ValidToken);
        writer.WriteVarInt(Ticket.Count());
        foreach (sbyte objectToSend in Ticket) writer.WriteSByte(objectToSend);
        writer.WriteShort(HomeServerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ValidToken = reader.ReadBoolean();
        int ticketCount = reader.ReadVarInt();
        var ticket_ = new sbyte[ticketCount];
        for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++) ticket_[ticketIndex] = reader.ReadSByte();
        Ticket = ticket_;
        HomeServerId = reader.ReadShort();
    }
}