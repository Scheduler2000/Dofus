using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AuthenticationTicketMessage : Message
{
    public const uint Id = 9517;

    public AuthenticationTicketMessage(string lang, string ticket)
    {
        Lang = lang;
        Ticket = ticket;
    }

    public AuthenticationTicketMessage()
    {
    }

    public override uint MessageId => Id;

    public string Lang { get; set; }

    public string Ticket { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Lang);
        writer.WriteUTF(Ticket);
    }

    public override void Deserialize(IDataReader reader)
    {
        Lang = reader.ReadUTF();
        Ticket = reader.ReadUTF();
    }
}