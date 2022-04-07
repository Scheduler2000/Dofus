using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextRemoveMultipleElementsMessage : Message
{
    public const uint Id = 9667;

    public GameContextRemoveMultipleElementsMessage(IEnumerable<double> elementsIds)
    {
        ElementsIds = elementsIds;
    }

    public GameContextRemoveMultipleElementsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<double> ElementsIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ElementsIds.Count());
        foreach (double objectToSend in ElementsIds) writer.WriteDouble(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort elementsIdsCount = reader.ReadUShort();
        var elementsIds_ = new double[elementsIdsCount];

        for (var elementsIdsIndex = 0; elementsIdsIndex < elementsIdsCount; elementsIdsIndex++)
            elementsIds_[elementsIdsIndex] = reader.ReadDouble();
        ElementsIds = elementsIds_;
    }
}