using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseGenericItemAddedMessage : Message
{
    public const uint Id = 7602;

    public ExchangeBidHouseGenericItemAddedMessage(ushort objGenericId)
    {
        ObjGenericId = objGenericId;
    }

    public ExchangeBidHouseGenericItemAddedMessage()
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