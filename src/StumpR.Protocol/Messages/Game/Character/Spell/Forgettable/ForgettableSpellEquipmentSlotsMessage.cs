using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ForgettableSpellEquipmentSlotsMessage : Message
{
    public const uint Id = 7772;

    public ForgettableSpellEquipmentSlotsMessage(short quantity)
    {
        Quantity = quantity;
    }

    public ForgettableSpellEquipmentSlotsMessage()
    {
    }

    public override uint MessageId => Id;

    public short Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarShort(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        Quantity = reader.ReadVarShort();
    }
}