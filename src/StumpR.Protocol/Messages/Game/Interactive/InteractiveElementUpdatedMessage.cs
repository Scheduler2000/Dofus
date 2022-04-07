using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InteractiveElementUpdatedMessage : Message
{
    public const uint Id = 7321;

    public InteractiveElementUpdatedMessage(InteractiveElement interactiveElement)
    {
        InteractiveElement = interactiveElement;
    }

    public InteractiveElementUpdatedMessage()
    {
    }

    public override uint MessageId => Id;

    public InteractiveElement InteractiveElement { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        InteractiveElement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        InteractiveElement = new InteractiveElement();
        InteractiveElement.Deserialize(reader);
    }
}