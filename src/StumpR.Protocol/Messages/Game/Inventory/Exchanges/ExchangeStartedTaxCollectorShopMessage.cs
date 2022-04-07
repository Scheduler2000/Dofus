using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartedTaxCollectorShopMessage : Message
{
    public const uint Id = 2236;

    public ExchangeStartedTaxCollectorShopMessage(IEnumerable<ObjectItem> objects, ulong kamas)
    {
        Objects = objects;
        Kamas = kamas;
    }

    public ExchangeStartedTaxCollectorShopMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItem> Objects { get; set; }

    public ulong Kamas { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Objects.Count());
        foreach (ObjectItem objectToSend in Objects) objectToSend.Serialize(writer);
        writer.WriteVarULong(Kamas);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectsCount = reader.ReadUShort();
        var objects_ = new ObjectItem[objectsCount];

        for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            objects_[objectsIndex] = objectToAdd;
        }
        Objects = objects_;
        Kamas = reader.ReadVarULong();
    }
}