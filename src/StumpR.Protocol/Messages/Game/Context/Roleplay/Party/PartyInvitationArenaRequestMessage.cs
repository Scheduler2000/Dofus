using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationArenaRequestMessage : PartyInvitationRequestMessage
{
    public new const uint Id = 8528;

    public PartyInvitationArenaRequestMessage(AbstractPlayerSearchInformation target)
    {
        Target = target;
    }

    public PartyInvitationArenaRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}