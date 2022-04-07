using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiBufferListRequestMessage : Message
{
    public const uint Id = 9520;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}