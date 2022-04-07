using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationRequestMessage : Message
{
    public const uint Id = 6419;

    public PartyInvitationRequestMessage(AbstractPlayerSearchInformation target)
    {
        Target = target;
    }

    public PartyInvitationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public AbstractPlayerSearchInformation Target { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Target.TypeId);
        Target.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Target = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
        Target.Deserialize(reader);
    }
}