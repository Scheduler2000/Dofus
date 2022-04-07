using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class DecraftedItemStackInfo
{
    public const short Id = 8215;

    public DecraftedItemStackInfo(uint objectUID, float bonusMin, float bonusMax, IEnumerable<ushort> runesId, IEnumerable<uint> runesQty)
    {
        ObjectUID = objectUID;
        BonusMin = bonusMin;
        BonusMax = bonusMax;
        RunesId = runesId;
        RunesQty = runesQty;
    }

    public DecraftedItemStackInfo()
    {
    }

    public virtual short TypeId => Id;

    public uint ObjectUID { get; set; }

    public float BonusMin { get; set; }

    public float BonusMax { get; set; }

    public IEnumerable<ushort> RunesId { get; set; }

    public IEnumerable<uint> RunesQty { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
        writer.WriteFloat(BonusMin);
        writer.WriteFloat(BonusMax);
        writer.WriteShort((short) RunesId.Count());
        foreach (ushort objectToSend in RunesId) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) RunesQty.Count());
        foreach (uint objectToSend in RunesQty) writer.WriteVarUInt(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
        BonusMin = reader.ReadFloat();
        BonusMax = reader.ReadFloat();
        ushort runesIdCount = reader.ReadUShort();
        var runesId_ = new ushort[runesIdCount];
        for (var runesIdIndex = 0; runesIdIndex < runesIdCount; runesIdIndex++) runesId_[runesIdIndex] = reader.ReadVarUShort();
        RunesId = runesId_;
        ushort runesQtyCount = reader.ReadUShort();
        var runesQty_ = new uint[runesQtyCount];
        for (var runesQtyIndex = 0; runesQtyIndex < runesQtyCount; runesQtyIndex++) runesQty_[runesQtyIndex] = reader.ReadVarUInt();
        RunesQty = runesQty_;
    }
}