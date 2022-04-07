using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HouseInformationsForSell
{
    public const short Id = 1011;

    public HouseInformationsForSell(int instanceId,
        bool secondHand,
        uint modelId,
        AccountTagInformation ownerTag,
        bool hasOwner,
        string ownerCharacterName,
        short worldX,
        short worldY,
        ushort subAreaId,
        sbyte nbRoom,
        sbyte nbChest,
        IEnumerable<int> skillListIds,
        bool isLocked,
        ulong price)
    {
        InstanceId = instanceId;
        SecondHand = secondHand;
        ModelId = modelId;
        OwnerTag = ownerTag;
        HasOwner = hasOwner;
        OwnerCharacterName = ownerCharacterName;
        WorldX = worldX;
        WorldY = worldY;
        SubAreaId = subAreaId;
        NbRoom = nbRoom;
        NbChest = nbChest;
        SkillListIds = skillListIds;
        IsLocked = isLocked;
        Price = price;
    }

    public HouseInformationsForSell()
    {
    }

    public virtual short TypeId => Id;

    public int InstanceId { get; set; }

    public bool SecondHand { get; set; }

    public uint ModelId { get; set; }

    public AccountTagInformation OwnerTag { get; set; }

    public bool HasOwner { get; set; }

    public string OwnerCharacterName { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public ushort SubAreaId { get; set; }

    public sbyte NbRoom { get; set; }

    public sbyte NbChest { get; set; }

    public IEnumerable<int> SkillListIds { get; set; }

    public bool IsLocked { get; set; }

    public ulong Price { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(SecondHand);
        writer.WriteVarUInt(ModelId);
        OwnerTag.Serialize(writer);
        writer.WriteBoolean(HasOwner);
        writer.WriteUTF(OwnerCharacterName);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteSByte(NbRoom);
        writer.WriteSByte(NbChest);
        writer.WriteShort((short) SkillListIds.Count());
        foreach (int objectToSend in SkillListIds) writer.WriteInt(objectToSend);
        writer.WriteBoolean(IsLocked);
        writer.WriteVarULong(Price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        InstanceId = reader.ReadInt();
        SecondHand = reader.ReadBoolean();
        ModelId = reader.ReadVarUInt();
        OwnerTag = new AccountTagInformation();
        OwnerTag.Deserialize(reader);
        HasOwner = reader.ReadBoolean();
        OwnerCharacterName = reader.ReadUTF();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        SubAreaId = reader.ReadVarUShort();
        NbRoom = reader.ReadSByte();
        NbChest = reader.ReadSByte();
        ushort skillListIdsCount = reader.ReadUShort();
        var skillListIds_ = new int[skillListIdsCount];

        for (var skillListIdsIndex = 0; skillListIdsIndex < skillListIdsCount; skillListIdsIndex++)
            skillListIds_[skillListIdsIndex] = reader.ReadInt();
        SkillListIds = skillListIds_;
        IsLocked = reader.ReadBoolean();
        Price = reader.ReadVarULong();
    }
}