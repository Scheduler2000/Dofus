using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InteractiveMapUpdateMessage : Message
{
    public const uint Id = 8375;

    public InteractiveMapUpdateMessage(IEnumerable<InteractiveElement> interactiveElements)
    {
        InteractiveElements = interactiveElements;
    }

    public InteractiveMapUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<InteractiveElement> InteractiveElements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) InteractiveElements.Count());

        foreach (InteractiveElement objectToSend in InteractiveElements)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort interactiveElementsCount = reader.ReadUShort();
        var interactiveElements_ = new InteractiveElement[interactiveElementsCount];

        for (var interactiveElementsIndex = 0; interactiveElementsIndex < interactiveElementsCount; interactiveElementsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            interactiveElements_[interactiveElementsIndex] = objectToAdd;
        }
        InteractiveElements = interactiveElements_;
    }
}