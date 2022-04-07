using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AnomalySubareaInformationRequestMessage : Message
{
    public const uint Id = 5877;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}