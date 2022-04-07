using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaSwitchToFightServerMessage : Message
{
    public const uint Id = 3316;

    public GameRolePlayArenaSwitchToFightServerMessage(string address, IEnumerable<ushort> ports, IEnumerable<sbyte> ticket)
    {
        Address = address;
        Ports = ports;
        Ticket = ticket;
    }

    public GameRolePlayArenaSwitchToFightServerMessage()
    {
    }

    public override uint MessageId => Id;

    public string Address { get; set; }

    public IEnumerable<ushort> Ports { get; set; }

    public IEnumerable<sbyte> Ticket { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Address);
        writer.WriteShort((short) Ports.Count());
        foreach (ushort objectToSend in Ports) writer.WriteVarUShort(objectToSend);
        writer.WriteVarInt(Ticket.Count());
        foreach (sbyte objectToSend in Ticket) writer.WriteSByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        Address = reader.ReadUTF();
        ushort portsCount = reader.ReadUShort();
        var ports_ = new ushort[portsCount];
        for (var portsIndex = 0; portsIndex < portsCount; portsIndex++) ports_[portsIndex] = reader.ReadVarUShort();
        Ports = ports_;
        int ticketCount = reader.ReadVarInt();
        var ticket_ = new sbyte[ticketCount];
        for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++) ticket_[ticketIndex] = reader.ReadSByte();
        Ticket = ticket_;
    }
}