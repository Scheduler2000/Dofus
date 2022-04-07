using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InventoryWeightMessage : Message
{
    public const uint Id = 3751;

    public InventoryWeightMessage(uint inventoryWeight, uint shopWeight, uint weightMax)
    {
        InventoryWeight = inventoryWeight;
        ShopWeight = shopWeight;
        WeightMax = weightMax;
    }

    public InventoryWeightMessage()
    {
    }

    public override uint MessageId => Id;

    public uint InventoryWeight { get; set; }

    public uint ShopWeight { get; set; }

    public uint WeightMax { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(InventoryWeight);
        writer.WriteVarUInt(ShopWeight);
        writer.WriteVarUInt(WeightMax);
    }

    public override void Deserialize(IDataReader reader)
    {
        InventoryWeight = reader.ReadVarUInt();
        ShopWeight = reader.ReadVarUInt();
        WeightMax = reader.ReadVarUInt();
    }
}