using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SelectedServerDataMessage : Message
{
    public const uint Id = 3966;

    public SelectedServerDataMessage(ushort serverId,
        string address,
        IEnumerable<ushort> ports,
        bool canCreateNewCharacter,
        IEnumerable<sbyte> ticket)
    {
        ServerId = serverId;
        Address = address;
        Ports = ports;
        CanCreateNewCharacter = canCreateNewCharacter;
        Ticket = ticket;
    }

    public SelectedServerDataMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ServerId { get; set; }

    public string Address { get; set; }

    public IEnumerable<ushort> Ports { get; set; }

    public bool CanCreateNewCharacter { get; set; }

    public IEnumerable<sbyte> Ticket { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ServerId);
        writer.WriteUTF(Address);
        writer.WriteShort((short) Ports.Count());
        foreach (ushort objectToSend in Ports) writer.WriteVarUShort(objectToSend);
        writer.WriteBoolean(CanCreateNewCharacter);
        writer.WriteVarInt(Ticket.Count());
        foreach (sbyte objectToSend in Ticket) writer.WriteSByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ServerId = reader.ReadVarUShort();
        Address = reader.ReadUTF();
        ushort portsCount = reader.ReadUShort();
        var ports_ = new ushort[portsCount];
        for (var portsIndex = 0; portsIndex < portsCount; portsIndex++) ports_[portsIndex] = reader.ReadVarUShort();
        Ports = ports_;
        CanCreateNewCharacter = reader.ReadBoolean();
        int ticketCount = reader.ReadVarInt();
        var ticket_ = new sbyte[ticketCount];
        for (var ticketIndex = 0; ticketIndex < ticketCount; ticketIndex++) ticket_[ticketIndex] = reader.ReadSByte();
        Ticket = ticket_;
    }
}