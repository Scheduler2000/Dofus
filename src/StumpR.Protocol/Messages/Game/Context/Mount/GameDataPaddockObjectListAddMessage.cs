using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameDataPaddockObjectListAddMessage : Message
{
    public const uint Id = 6584;

    public GameDataPaddockObjectListAddMessage(IEnumerable<PaddockItem> paddockItemDescription)
    {
        PaddockItemDescription = paddockItemDescription;
    }

    public GameDataPaddockObjectListAddMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<PaddockItem> PaddockItemDescription { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PaddockItemDescription.Count());
        foreach (PaddockItem objectToSend in PaddockItemDescription) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort paddockItemDescriptionCount = reader.ReadUShort();
        var paddockItemDescription_ = new PaddockItem[paddockItemDescriptionCount];

        for (var paddockItemDescriptionIndex = 0;
             paddockItemDescriptionIndex < paddockItemDescriptionCount;
             paddockItemDescriptionIndex++)
        {
            var objectToAdd = new PaddockItem();
            objectToAdd.Deserialize(reader);
            paddockItemDescription_[paddockItemDescriptionIndex] = objectToAdd;
        }
        PaddockItemDescription = paddockItemDescription_;
    }
}