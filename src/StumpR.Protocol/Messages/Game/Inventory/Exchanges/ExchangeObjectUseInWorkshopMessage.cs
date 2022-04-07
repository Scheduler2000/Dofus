using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectUseInWorkshopMessage : Message
{
    public const uint Id = 5412;

    public ExchangeObjectUseInWorkshopMessage(uint objectUID, int quantity)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ExchangeObjectUseInWorkshopMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public int Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
        writer.WriteVarInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
        Quantity = reader.ReadVarInt();
    }
}