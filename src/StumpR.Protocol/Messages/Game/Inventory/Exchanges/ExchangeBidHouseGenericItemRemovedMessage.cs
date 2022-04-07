using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseGenericItemRemovedMessage : Message
{
    public const uint Id = 9780;

    public ExchangeBidHouseGenericItemRemovedMessage(ushort objGenericId)
    {
        ObjGenericId = objGenericId;
    }

    public ExchangeBidHouseGenericItemRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ObjGenericId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjGenericId = reader.ReadVarUShort();
    }
}