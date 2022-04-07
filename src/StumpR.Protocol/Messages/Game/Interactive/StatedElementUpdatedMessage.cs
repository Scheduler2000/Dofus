using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StatedElementUpdatedMessage : Message
{
    public const uint Id = 3961;

    public StatedElementUpdatedMessage(StatedElement statedElement)
    {
        StatedElement = statedElement;
    }

    public StatedElementUpdatedMessage()
    {
    }

    public override uint MessageId => Id;

    public StatedElement StatedElement { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        StatedElement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        StatedElement = new StatedElement();
        StatedElement.Deserialize(reader);
    }
}