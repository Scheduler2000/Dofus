using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AcquaintanceAddedMessage : Message
{
    public const uint Id = 6756;

    public AcquaintanceAddedMessage(AcquaintanceInformation acquaintanceAdded)
    {
        AcquaintanceAdded = acquaintanceAdded;
    }

    public AcquaintanceAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public AcquaintanceInformation AcquaintanceAdded { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(AcquaintanceAdded.TypeId);
        AcquaintanceAdded.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        AcquaintanceAdded = ProtocolTypeManager.GetInstance<AcquaintanceInformation>(reader.ReadShort());
        AcquaintanceAdded.Deserialize(reader);
    }
}