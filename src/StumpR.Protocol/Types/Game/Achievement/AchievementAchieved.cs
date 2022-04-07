using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AchievementAchieved
{
    public const short Id = 1836;

    public AchievementAchieved(ushort objectId, ulong achievedBy)
    {
        ObjectId = objectId;
        AchievedBy = achievedBy;
    }

    public AchievementAchieved()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObjectId { get; set; }

    public ulong AchievedBy { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteVarULong(AchievedBy);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        AchievedBy = reader.ReadVarULong();
    }
}