using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorLootInformations : TaxCollectorComplementaryInformations
{
    public new const short Id = 8142;

    public TaxCollectorLootInformations(ulong kamas, ulong experience, uint pods, ulong itemsValue)
    {
        Kamas = kamas;
        Experience = experience;
        Pods = pods;
        ItemsValue = itemsValue;
    }

    public TaxCollectorLootInformations()
    {
    }

    public override short TypeId => Id;

    public ulong Kamas { get; set; }

    public ulong Experience { get; set; }

    public uint Pods { get; set; }

    public ulong ItemsValue { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Kamas);
        writer.WriteVarULong(Experience);
        writer.WriteVarUInt(Pods);
        writer.WriteVarULong(ItemsValue);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Kamas = reader.ReadVarULong();
        Experience = reader.ReadVarULong();
        Pods = reader.ReadVarUInt();
        ItemsValue = reader.ReadVarULong();
    }
}