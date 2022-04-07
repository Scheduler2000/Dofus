using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobExperience
{
    public const short Id = 1579;

    public JobExperience(sbyte jobId, byte jobLevel, ulong jobXP, ulong jobXpLevelFloor, ulong jobXpNextLevelFloor)
    {
        JobId = jobId;
        JobLevel = jobLevel;
        JobXP = jobXP;
        JobXpLevelFloor = jobXpLevelFloor;
        JobXpNextLevelFloor = jobXpNextLevelFloor;
    }

    public JobExperience()
    {
    }

    public virtual short TypeId => Id;

    public sbyte JobId { get; set; }

    public byte JobLevel { get; set; }

    public ulong JobXP { get; set; }

    public ulong JobXpLevelFloor { get; set; }

    public ulong JobXpNextLevelFloor { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(JobId);
        writer.WriteByte(JobLevel);
        writer.WriteVarULong(JobXP);
        writer.WriteVarULong(JobXpLevelFloor);
        writer.WriteVarULong(JobXpNextLevelFloor);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        JobId = reader.ReadSByte();
        JobLevel = reader.ReadByte();
        JobXP = reader.ReadVarULong();
        JobXpLevelFloor = reader.ReadVarULong();
        JobXpNextLevelFloor = reader.ReadVarULong();
    }
}