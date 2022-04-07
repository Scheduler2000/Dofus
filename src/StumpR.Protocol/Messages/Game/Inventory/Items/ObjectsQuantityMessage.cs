using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectsQuantityMessage : Message
{
    public const uint Id = 5570;

    public ObjectsQuantityMessage(IEnumerable<ObjectItemQuantity> objectsUIDAndQty)
    {
        ObjectsUIDAndQty = objectsUIDAndQty;
    }

    public ObjectsQuantityMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItemQuantity> ObjectsUIDAndQty { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ObjectsUIDAndQty.Count());
        foreach (ObjectItemQuantity objectToSend in ObjectsUIDAndQty) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort objectsUIDAndQtyCount = reader.ReadUShort();
        var objectsUIDAndQty_ = new ObjectItemQuantity[objectsUIDAndQtyCount];

        for (var objectsUIDAndQtyIndex = 0; objectsUIDAndQtyIndex < objectsUIDAndQtyCount; objectsUIDAndQtyIndex++)
        {
            var objectToAdd = new ObjectItemQuantity();
            objectToAdd.Deserialize(reader);
            objectsUIDAndQty_[objectsUIDAndQtyIndex] = objectToAdd;
        }
        ObjectsUIDAndQty = objectsUIDAndQty_;
    }
}