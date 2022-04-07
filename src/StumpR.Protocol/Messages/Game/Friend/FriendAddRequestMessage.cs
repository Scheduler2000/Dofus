using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendAddRequestMessage : Message
{
    public const uint Id = 6214;

    public FriendAddRequestMessage(AbstractPlayerSearchInformation target)
    {
        Target = target;
    }

    public FriendAddRequestMessage()
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