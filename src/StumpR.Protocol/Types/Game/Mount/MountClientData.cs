using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MountClientData
{
    public const short Id = 9874;

    public MountClientData(bool sex,
        bool isRideable,
        bool isWild,
        bool isFecondationReady,
        bool useHarnessColors,
        double objectId,
        uint model,
        IEnumerable<int> ancestor,
        IEnumerable<int> behaviors,
        string name,
        int ownerId,
        ulong experience,
        ulong experienceForLevel,
        double experienceForNextLevel,
        sbyte level,
        uint maxPods,
        uint stamina,
        uint staminaMax,
        uint maturity,
        uint maturityForAdult,
        uint energy,
        uint energyMax,
        int serenity,
        int aggressivityMax,
        uint serenityMax,
        uint love,
        uint loveMax,
        int fecondationTime,
        int boostLimiter,
        double boostMax,
        int reproductionCount,
        uint reproductionCountMax,
        ushort harnessGID,
        IEnumerable<ObjectEffectInteger> effectList)
    {
        Sex = sex;
        IsRideable = isRideable;
        IsWild = isWild;
        IsFecondationReady = isFecondationReady;
        UseHarnessColors = useHarnessColors;
        ObjectId = objectId;
        Model = model;
        Ancestor = ancestor;
        Behaviors = behaviors;
        Name = name;
        OwnerId = ownerId;
        Experience = experience;
        ExperienceForLevel = experienceForLevel;
        ExperienceForNextLevel = experienceForNextLevel;
        Level = level;
        MaxPods = maxPods;
        Stamina = stamina;
        StaminaMax = staminaMax;
        Maturity = maturity;
        MaturityForAdult = maturityForAdult;
        Energy = energy;
        EnergyMax = energyMax;
        Serenity = serenity;
        AggressivityMax = aggressivityMax;
        SerenityMax = serenityMax;
        Love = love;
        LoveMax = loveMax;
        FecondationTime = fecondationTime;
        BoostLimiter = boostLimiter;
        BoostMax = boostMax;
        ReproductionCount = reproductionCount;
        ReproductionCountMax = reproductionCountMax;
        HarnessGID = harnessGID;
        EffectList = effectList;
    }

    public MountClientData()
    {
    }

    public virtual short TypeId => Id;

    public bool Sex { get; set; }

    public bool IsRideable { get; set; }

    public bool IsWild { get; set; }

    public bool IsFecondationReady { get; set; }

    public bool UseHarnessColors { get; set; }

    public double ObjectId { get; set; }

    public uint Model { get; set; }

    public IEnumerable<int> Ancestor { get; set; }

    public IEnumerable<int> Behaviors { get; set; }

    public string Name { get; set; }

    public int OwnerId { get; set; }

    public ulong Experience { get; set; }

    public ulong ExperienceForLevel { get; set; }

    public double ExperienceForNextLevel { get; set; }

    public sbyte Level { get; set; }

    public uint MaxPods { get; set; }

    public uint Stamina { get; set; }

    public uint StaminaMax { get; set; }

    public uint Maturity { get; set; }

    public uint MaturityForAdult { get; set; }

    public uint Energy { get; set; }

    public uint EnergyMax { get; set; }

    public int Serenity { get; set; }

    public int AggressivityMax { get; set; }

    public uint SerenityMax { get; set; }

    public uint Love { get; set; }

    public uint LoveMax { get; set; }

    public int FecondationTime { get; set; }

    public int BoostLimiter { get; set; }

    public double BoostMax { get; set; }

    public int ReproductionCount { get; set; }

    public uint ReproductionCountMax { get; set; }

    public ushort HarnessGID { get; set; }

    public IEnumerable<ObjectEffectInteger> EffectList { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Sex);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsRideable);
        flag = BooleanByteWrapper.SetFlag(flag, 2, IsWild);
        flag = BooleanByteWrapper.SetFlag(flag, 3, IsFecondationReady);
        flag = BooleanByteWrapper.SetFlag(flag, 4, UseHarnessColors);
        writer.WriteByte(flag);
        writer.WriteDouble(ObjectId);
        writer.WriteVarUInt(Model);
        writer.WriteShort((short) Ancestor.Count());
        foreach (int objectToSend in Ancestor) writer.WriteInt(objectToSend);
        writer.WriteShort((short) Behaviors.Count());
        foreach (int objectToSend in Behaviors) writer.WriteInt(objectToSend);
        writer.WriteUTF(Name);
        writer.WriteInt(OwnerId);
        writer.WriteVarULong(Experience);
        writer.WriteVarULong(ExperienceForLevel);
        writer.WriteDouble(ExperienceForNextLevel);
        writer.WriteSByte(Level);
        writer.WriteVarUInt(MaxPods);
        writer.WriteVarUInt(Stamina);
        writer.WriteVarUInt(StaminaMax);
        writer.WriteVarUInt(Maturity);
        writer.WriteVarUInt(MaturityForAdult);
        writer.WriteVarUInt(Energy);
        writer.WriteVarUInt(EnergyMax);
        writer.WriteInt(Serenity);
        writer.WriteInt(AggressivityMax);
        writer.WriteVarUInt(SerenityMax);
        writer.WriteVarUInt(Love);
        writer.WriteVarUInt(LoveMax);
        writer.WriteInt(FecondationTime);
        writer.WriteInt(BoostLimiter);
        writer.WriteDouble(BoostMax);
        writer.WriteInt(ReproductionCount);
        writer.WriteVarUInt(ReproductionCountMax);
        writer.WriteVarUShort(HarnessGID);
        writer.WriteShort((short) EffectList.Count());
        foreach (ObjectEffectInteger objectToSend in EffectList) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Sex = BooleanByteWrapper.GetFlag(flag, 0);
        IsRideable = BooleanByteWrapper.GetFlag(flag, 1);
        IsWild = BooleanByteWrapper.GetFlag(flag, 2);
        IsFecondationReady = BooleanByteWrapper.GetFlag(flag, 3);
        UseHarnessColors = BooleanByteWrapper.GetFlag(flag, 4);
        ObjectId = reader.ReadDouble();
        Model = reader.ReadVarUInt();
        ushort ancestorCount = reader.ReadUShort();
        var ancestor_ = new int[ancestorCount];
        for (var ancestorIndex = 0; ancestorIndex < ancestorCount; ancestorIndex++) ancestor_[ancestorIndex] = reader.ReadInt();
        Ancestor = ancestor_;
        ushort behaviorsCount = reader.ReadUShort();
        var behaviors_ = new int[behaviorsCount];
        for (var behaviorsIndex = 0; behaviorsIndex < behaviorsCount; behaviorsIndex++) behaviors_[behaviorsIndex] = reader.ReadInt();
        Behaviors = behaviors_;
        Name = reader.ReadUTF();
        OwnerId = reader.ReadInt();
        Experience = reader.ReadVarULong();
        ExperienceForLevel = reader.ReadVarULong();
        ExperienceForNextLevel = reader.ReadDouble();
        Level = reader.ReadSByte();
        MaxPods = reader.ReadVarUInt();
        Stamina = reader.ReadVarUInt();
        StaminaMax = reader.ReadVarUInt();
        Maturity = reader.ReadVarUInt();
        MaturityForAdult = reader.ReadVarUInt();
        Energy = reader.ReadVarUInt();
        EnergyMax = reader.ReadVarUInt();
        Serenity = reader.ReadInt();
        AggressivityMax = reader.ReadInt();
        SerenityMax = reader.ReadVarUInt();
        Love = reader.ReadVarUInt();
        LoveMax = reader.ReadVarUInt();
        FecondationTime = reader.ReadInt();
        BoostLimiter = reader.ReadInt();
        BoostMax = reader.ReadDouble();
        ReproductionCount = reader.ReadInt();
        ReproductionCountMax = reader.ReadVarUInt();
        HarnessGID = reader.ReadVarUShort();
        ushort effectListCount = reader.ReadUShort();
        var effectList_ = new ObjectEffectInteger[effectListCount];

        for (var effectListIndex = 0; effectListIndex < effectListCount; effectListIndex++)
        {
            var objectToAdd = new ObjectEffectInteger();
            objectToAdd.Deserialize(reader);
            effectList_[effectListIndex] = objectToAdd;
        }
        EffectList = effectList_;
    }
}