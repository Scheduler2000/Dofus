using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInfosUpgradeMessage : Message
{
    public const uint Id = 2887;

    public GuildInfosUpgradeMessage(sbyte maxTaxCollectorsCount,
        sbyte taxCollectorsCount,
        ushort taxCollectorLifePoints,
        ushort taxCollectorDamagesBonuses,
        ushort taxCollectorPods,
        ushort taxCollectorProspecting,
        ushort taxCollectorWisdom,
        ushort boostPoints,
        IEnumerable<ushort> spellId,
        IEnumerable<short> spellLevel)
    {
        MaxTaxCollectorsCount = maxTaxCollectorsCount;
        TaxCollectorsCount = taxCollectorsCount;
        TaxCollectorLifePoints = taxCollectorLifePoints;
        TaxCollectorDamagesBonuses = taxCollectorDamagesBonuses;
        TaxCollectorPods = taxCollectorPods;
        TaxCollectorProspecting = taxCollectorProspecting;
        TaxCollectorWisdom = taxCollectorWisdom;
        BoostPoints = boostPoints;
        SpellId = spellId;
        SpellLevel = spellLevel;
    }

    public GuildInfosUpgradeMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte MaxTaxCollectorsCount { get; set; }

    public sbyte TaxCollectorsCount { get; set; }

    public ushort TaxCollectorLifePoints { get; set; }

    public ushort TaxCollectorDamagesBonuses { get; set; }

    public ushort TaxCollectorPods { get; set; }

    public ushort TaxCollectorProspecting { get; set; }

    public ushort TaxCollectorWisdom { get; set; }

    public ushort BoostPoints { get; set; }

    public IEnumerable<ushort> SpellId { get; set; }

    public IEnumerable<short> SpellLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(MaxTaxCollectorsCount);
        writer.WriteSByte(TaxCollectorsCount);
        writer.WriteVarUShort(TaxCollectorLifePoints);
        writer.WriteVarUShort(TaxCollectorDamagesBonuses);
        writer.WriteVarUShort(TaxCollectorPods);
        writer.WriteVarUShort(TaxCollectorProspecting);
        writer.WriteVarUShort(TaxCollectorWisdom);
        writer.WriteVarUShort(BoostPoints);
        writer.WriteShort((short) SpellId.Count());
        foreach (ushort objectToSend in SpellId) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) SpellLevel.Count());
        foreach (short objectToSend in SpellLevel) writer.WriteShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        MaxTaxCollectorsCount = reader.ReadSByte();
        TaxCollectorsCount = reader.ReadSByte();
        TaxCollectorLifePoints = reader.ReadVarUShort();
        TaxCollectorDamagesBonuses = reader.ReadVarUShort();
        TaxCollectorPods = reader.ReadVarUShort();
        TaxCollectorProspecting = reader.ReadVarUShort();
        TaxCollectorWisdom = reader.ReadVarUShort();
        BoostPoints = reader.ReadVarUShort();
        ushort spellIdCount = reader.ReadUShort();
        var spellId_ = new ushort[spellIdCount];
        for (var spellIdIndex = 0; spellIdIndex < spellIdCount; spellIdIndex++) spellId_[spellIdIndex] = reader.ReadVarUShort();
        SpellId = spellId_;
        ushort spellLevelCount = reader.ReadUShort();
        var spellLevel_ = new short[spellLevelCount];

        for (var spellLevelIndex = 0; spellLevelIndex < spellLevelCount; spellLevelIndex++)
            spellLevel_[spellLevelIndex] = reader.ReadShort();
        SpellLevel = spellLevel_;
    }
}