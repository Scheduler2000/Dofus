using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IgnoredAddRequestMessage : Message
{
    public const uint Id = 2801;

    public IgnoredAddRequestMessage(AbstractPlayerSearchInformation target, bool session)
    {
        Target = target;
        Session = session;
    }

    public IgnoredAddRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public AbstractPlayerSearchInformation Target { get; set; }

    public bool Session { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Target.TypeId);
        Target.Serialize(writer);
        writer.WriteBoolean(Session);
    }

    public override void Deserialize(IDataReader reader)
    {
        Target = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
        Target.Deserialize(reader);
        Session = reader.ReadBoolean();
    }
}