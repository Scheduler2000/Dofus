using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachInvitationResponseMessage : Message
{
    public const uint Id = 6585;

    public BreachInvitationResponseMessage(CharacterMinimalInformations guest, bool accept)
    {
        Guest = guest;
        Accept = accept;
    }

    public BreachInvitationResponseMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterMinimalInformations Guest { get; set; }

    public bool Accept { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Guest.Serialize(writer);
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(IDataReader reader)
    {
        Guest = new CharacterMinimalInformations();
        Guest.Deserialize(reader);
        Accept = reader.ReadBoolean();
    }
}