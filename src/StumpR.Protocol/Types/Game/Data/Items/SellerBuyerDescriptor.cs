using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SellerBuyerDescriptor
{
    public const short Id = 5475;

    public SellerBuyerDescriptor(IEnumerable<uint> quantities,
        IEnumerable<uint> types,
        float taxPercentage,
        float taxModificationPercentage,
        byte maxItemLevel,
        uint maxItemPerAccount,
        int npcContextualId,
        ushort unsoldDelay)
    {
        Quantities = quantities;
        Types = types;
        TaxPercentage = taxPercentage;
        TaxModificationPercentage = taxModificationPercentage;
        MaxItemLevel = maxItemLevel;
        MaxItemPerAccount = maxItemPerAccount;
        NpcContextualId = npcContextualId;
        UnsoldDelay = unsoldDelay;
    }

    public SellerBuyerDescriptor()
    {
    }

    public virtual short TypeId => Id;

    public IEnumerable<uint> Quantities { get; set; }

    public IEnumerable<uint> Types { get; set; }

    public float TaxPercentage { get; set; }

    public float TaxModificationPercentage { get; set; }

    public byte MaxItemLevel { get; set; }

    public uint MaxItemPerAccount { get; set; }

    public int NpcContextualId { get; set; }

    public ushort UnsoldDelay { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Quantities.Count());
        foreach (uint objectToSend in Quantities) writer.WriteVarUInt(objectToSend);
        writer.WriteShort((short) Types.Count());
        foreach (uint objectToSend in Types) writer.WriteVarUInt(objectToSend);
        writer.WriteFloat(TaxPercentage);
        writer.WriteFloat(TaxModificationPercentage);
        writer.WriteByte(MaxItemLevel);
        writer.WriteVarUInt(MaxItemPerAccount);
        writer.WriteInt(NpcContextualId);
        writer.WriteVarUShort(UnsoldDelay);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ushort quantitiesCount = reader.ReadUShort();
        var quantities_ = new uint[quantitiesCount];

        for (var quantitiesIndex = 0; quantitiesIndex < quantitiesCount; quantitiesIndex++)
            quantities_[quantitiesIndex] = reader.ReadVarUInt();
        Quantities = quantities_;
        ushort typesCount = reader.ReadUShort();
        var types_ = new uint[typesCount];
        for (var typesIndex = 0; typesIndex < typesCount; typesIndex++) types_[typesIndex] = reader.ReadVarUInt();
        Types = types_;
        TaxPercentage = reader.ReadFloat();
        TaxModificationPercentage = reader.ReadFloat();
        MaxItemLevel = reader.ReadByte();
        MaxItemPerAccount = reader.ReadVarUInt();
        NpcContextualId = reader.ReadInt();
        UnsoldDelay = reader.ReadVarUShort();
    }
}