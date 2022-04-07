using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AnomalySubareaInformation
{
    public const short Id = 8338;

    public AnomalySubareaInformation(ushort subAreaId, short rewardRate, bool hasAnomaly, ulong anomalyClosingTime)
    {
        SubAreaId = subAreaId;
        RewardRate = rewardRate;
        HasAnomaly = hasAnomaly;
        AnomalyClosingTime = anomalyClosingTime;
    }

    public AnomalySubareaInformation()
    {
    }

    public virtual short TypeId => Id;

    public ushort SubAreaId { get; set; }

    public short RewardRate { get; set; }

    public bool HasAnomaly { get; set; }

    public ulong AnomalyClosingTime { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteVarShort(RewardRate);
        writer.WriteBoolean(HasAnomaly);
        writer.WriteVarULong(AnomalyClosingTime);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        RewardRate = reader.ReadVarShort();
        HasAnomaly = reader.ReadBoolean();
        AnomalyClosingTime = reader.ReadVarULong();
    }
}