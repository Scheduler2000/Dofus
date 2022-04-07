using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage
{
    public new const uint Id = 7428;

    public GameContextRemoveMultipleElementsWithEventsMessage(IEnumerable<double> elementsIds, IEnumerable<byte> elementEventIds)
    {
        ElementsIds = elementsIds;
        ElementEventIds = elementEventIds;
    }

    public GameContextRemoveMultipleElementsWithEventsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<byte> ElementEventIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) ElementEventIds.Count());
        foreach (byte objectToSend in ElementEventIds) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort elementEventIdsCount = reader.ReadUShort();
        var elementEventIds_ = new byte[elementEventIdsCount];

        for (var elementEventIdsIndex = 0; elementEventIdsIndex < elementEventIdsCount; elementEventIdsIndex++)
            elementEventIds_[elementEventIdsIndex] = reader.ReadByte();
        ElementEventIds = elementEventIds_;
    }
}