using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachInvitationCloseMessage : Message
{
    public const uint Id = 3262;

    public BreachInvitationCloseMessage(CharacterMinimalInformations host)
    {
        Host = host;
    }

    public BreachInvitationCloseMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterMinimalInformations Host { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Host.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Host = new CharacterMinimalInformations();
        Host.Deserialize(reader);
    }
}