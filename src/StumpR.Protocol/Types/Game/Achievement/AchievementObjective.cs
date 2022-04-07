using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AchievementObjective
{
    public const short Id = 8917;

    public AchievementObjective(uint objectId, ushort maxValue)
    {
        ObjectId = objectId;
        MaxValue = maxValue;
    }

    public AchievementObjective()
    {
    }

    public virtual short TypeId => Id;

    public uint ObjectId { get; set; }

    public ushort MaxValue { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectId);
        writer.WriteVarUShort(MaxValue);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUInt();
        MaxValue = reader.ReadVarUShort();
    }
}