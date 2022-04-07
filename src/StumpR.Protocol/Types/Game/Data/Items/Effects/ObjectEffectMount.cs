using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectMount : ObjectEffect
{
    public new const short Id = 4916;

    public ObjectEffectMount(ushort actionId,
        bool sex,
        bool isRideable,
        bool isFeconded,
        bool isFecondationReady,
        ulong objectId,
        ulong expirationDate,
        uint model,
        string name,
        string owner,
        sbyte level,
        int reproductionCount,
        uint reproductionCountMax,
        IEnumerable<ObjectEffectInteger> effects,
        IEnumerable<uint> capacities)
    {
        ActionId = actionId;
        Sex = sex;
        IsRideable = isRideable;
        IsFeconded = isFeconded;
        IsFecondationReady = isFecondationReady;
        ObjectId = objectId;
        ExpirationDate = expirationDate;
        Model = model;
        Name = name;
        Owner = owner;
        Level = level;
        ReproductionCount = reproductionCount;
        ReproductionCountMax = reproductionCountMax;
        Effects = effects;
        Capacities = capacities;
    }

    public ObjectEffectMount()
    {
    }

    public override short TypeId => Id;

    public bool Sex { get; set; }

    public bool IsRideable { get; set; }

    public bool IsFeconded { get; set; }

    public bool IsFecondationReady { get; set; }

    public ulong ObjectId { get; set; }

    public ulong ExpirationDate { get; set; }

    public uint Model { get; set; }

    public string Name { get; set; }

    public string Owner { get; set; }

    public sbyte Level { get; set; }

    public int ReproductionCount { get; set; }

    public uint ReproductionCountMax { get; set; }

    public IEnumerable<ObjectEffectInteger> Effects { get; set; }

    public IEnumerable<uint> Capacities { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Sex);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsRideable);
        flag = BooleanByteWrapper.SetFlag(flag, 2, IsFeconded);
        flag = BooleanByteWrapper.SetFlag(flag, 3, IsFecondationReady);
        writer.WriteByte(flag);
        writer.WriteVarULong(ObjectId);
        writer.WriteVarULong(ExpirationDate);
        writer.WriteVarUInt(Model);
        writer.WriteUTF(Name);
        writer.WriteUTF(Owner);
        writer.WriteSByte(Level);
        writer.WriteVarInt(ReproductionCount);
        writer.WriteVarUInt(ReproductionCountMax);
        writer.WriteShort((short) Effects.Count());
        foreach (ObjectEffectInteger objectToSend in Effects) objectToSend.Serialize(writer);
        writer.WriteShort((short) Capacities.Count());
        foreach (uint objectToSend in Capacities) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        byte flag = reader.ReadByte();
        Sex = BooleanByteWrapper.GetFlag(flag, 0);
        IsRideable = BooleanByteWrapper.GetFlag(flag, 1);
        IsFeconded = BooleanByteWrapper.GetFlag(flag, 2);
        IsFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
        ObjectId = reader.ReadVarULong();
        ExpirationDate = reader.ReadVarULong();
        Model = reader.ReadVarUInt();
        Name = reader.ReadUTF();
        Owner = reader.ReadUTF();
        Level = reader.ReadSByte();
        ReproductionCount = reader.ReadVarInt();
        ReproductionCountMax = reader.ReadVarUInt();
        ushort effectsCount = reader.ReadUShort();
        var effects_ = new ObjectEffectInteger[effectsCount];

        for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
        {
            var objectToAdd = new ObjectEffectInteger();
            objectToAdd.Deserialize(reader);
            effects_[effectsIndex] = objectToAdd;
        }
        Effects = effects_;
        ushort capacitiesCount = reader.ReadUShort();
        var capacities_ = new uint[capacitiesCount];

        for (var capacitiesIndex = 0; capacitiesIndex < capacitiesCount; capacitiesIndex++)
            capacities_[capacitiesIndex] = reader.ReadVarUInt();
        Capacities = capacities_;
    }
}