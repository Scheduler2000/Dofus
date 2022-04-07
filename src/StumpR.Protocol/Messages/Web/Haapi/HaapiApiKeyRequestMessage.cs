using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiApiKeyRequestMessage : Message
{
    public const uint Id = 6036;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}