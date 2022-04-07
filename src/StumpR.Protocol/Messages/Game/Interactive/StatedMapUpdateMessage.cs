using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StatedMapUpdateMessage : Message
{
    public const uint Id = 8689;

    public StatedMapUpdateMessage(IEnumerable<StatedElement> statedElements)
    {
        StatedElements = statedElements;
    }

    public StatedMapUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<StatedElement> StatedElements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) StatedElements.Count());
        foreach (StatedElement objectToSend in StatedElements) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort statedElementsCount = reader.ReadUShort();
        var statedElements_ = new StatedElement[statedElementsCount];

        for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
        {
            var objectToAdd = new StatedElement();
            objectToAdd.Deserialize(reader);
            statedElements_[statedElementsIndex] = objectToAdd;
        }
        StatedElements = statedElements_;
    }
}