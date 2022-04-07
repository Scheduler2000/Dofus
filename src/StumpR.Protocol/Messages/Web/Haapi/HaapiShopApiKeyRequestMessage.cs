using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiShopApiKeyRequestMessage : Message
{
    public const uint Id = 4578;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}