using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HouseInstanceInformations
{
    public const short Id = 3243;

    public HouseInstanceInformations(bool secondHand,
        bool isLocked,
        bool hasOwner,
        bool isSaleLocked,
        int instanceId,
        AccountTagInformation ownerTag,
        long price)
    {
        SecondHand = secondHand;
        IsLocked = isLocked;
        HasOwner = hasOwner;
        IsSaleLocked = isSaleLocked;
        InstanceId = instanceId;
        OwnerTag = ownerTag;
        Price = price;
    }

    public HouseInstanceInformations()
    {
    }

    public virtual short TypeId => Id;

    public bool SecondHand { get; set; }

    public bool IsLocked { get; set; }

    public bool HasOwner { get; set; }

    public bool IsSaleLocked { get; set; }

    public int InstanceId { get; set; }

    public AccountTagInformation OwnerTag { get; set; }

    public long Price { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, SecondHand);
        flag = BooleanByteWrapper.SetFlag(flag, 1, IsLocked);
        flag = BooleanByteWrapper.SetFlag(flag, 2, HasOwner);
        flag = BooleanByteWrapper.SetFlag(flag, 3, IsSaleLocked);
        writer.WriteByte(flag);
        writer.WriteInt(InstanceId);
        OwnerTag.Serialize(writer);
        writer.WriteVarLong(Price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        SecondHand = BooleanByteWrapper.GetFlag(flag, 0);
        IsLocked = BooleanByteWrapper.GetFlag(flag, 1);
        HasOwner = BooleanByteWrapper.GetFlag(flag, 2);
        IsSaleLocked = BooleanByteWrapper.GetFlag(flag, 3);
        InstanceId = reader.ReadInt();
        OwnerTag = new AccountTagInformation();
        OwnerTag.Deserialize(reader);
        Price = reader.ReadVarLong();
    }
}