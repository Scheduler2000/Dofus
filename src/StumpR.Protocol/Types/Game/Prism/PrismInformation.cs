using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PrismInformation
{
    public const short Id = 6060;

    public PrismInformation(sbyte typeId, sbyte state, int nextVulnerabilityDate, int placementDate, uint rewardTokenCount)
    {
        this.typeId = typeId;
        State = state;
        NextVulnerabilityDate = nextVulnerabilityDate;
        PlacementDate = placementDate;
        RewardTokenCount = rewardTokenCount;
    }

    public PrismInformation()
    {
    }

    public virtual short TypeId => Id;

    public sbyte typeId { get; set; }

    public sbyte State { get; set; }

    public int NextVulnerabilityDate { get; set; }

    public int PlacementDate { get; set; }

    public uint RewardTokenCount { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(typeId);
        writer.WriteSByte(State);
        writer.WriteInt(NextVulnerabilityDate);
        writer.WriteInt(PlacementDate);
        writer.WriteVarUInt(RewardTokenCount);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        typeId = reader.ReadSByte();
        State = reader.ReadSByte();
        NextVulnerabilityDate = reader.ReadInt();
        PlacementDate = reader.ReadInt();
        RewardTokenCount = reader.ReadVarUInt();
    }
}