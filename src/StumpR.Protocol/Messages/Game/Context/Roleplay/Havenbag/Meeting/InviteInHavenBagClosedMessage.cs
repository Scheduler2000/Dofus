using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InviteInHavenBagClosedMessage : Message
{
    public const uint Id = 5490;

    public InviteInHavenBagClosedMessage(CharacterMinimalInformations hostInformations)
    {
        HostInformations = hostInformations;
    }

    public InviteInHavenBagClosedMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterMinimalInformations HostInformations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        HostInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        HostInformations = new CharacterMinimalInformations();
        HostInformations.Deserialize(reader);
    }
}