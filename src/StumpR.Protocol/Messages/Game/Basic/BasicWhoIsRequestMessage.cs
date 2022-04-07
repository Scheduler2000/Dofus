using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicWhoIsRequestMessage : Message
{
    public const uint Id = 1784;

    public BasicWhoIsRequestMessage(bool verbose, AbstractPlayerSearchInformation target)
    {
        Verbose = verbose;
        Target = target;
    }

    public BasicWhoIsRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Verbose { get; set; }

    public AbstractPlayerSearchInformation Target { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Verbose);
        writer.WriteShort(Target.TypeId);
        Target.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Verbose = reader.ReadBoolean();
        Target = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
        Target.Deserialize(reader);
    }
}