using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendJoinRequestMessage : Message
{
    public const uint Id = 535;

    public FriendJoinRequestMessage(AbstractPlayerSearchInformation target)
    {
        Target = target;
    }

    public FriendJoinRequestMessage()
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