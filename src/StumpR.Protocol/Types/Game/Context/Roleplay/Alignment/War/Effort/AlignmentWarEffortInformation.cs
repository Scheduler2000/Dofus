using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AlignmentWarEffortInformation
{
    public const short Id = 3356;

    public AlignmentWarEffortInformation(sbyte alignmentSide, ulong alignmentWarEffort)
    {
        AlignmentSide = alignmentSide;
        AlignmentWarEffort = alignmentWarEffort;
    }

    public AlignmentWarEffortInformation()
    {
    }

    public virtual short TypeId => Id;

    public sbyte AlignmentSide { get; set; }

    public ulong AlignmentWarEffort { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(AlignmentSide);
        writer.WriteVarULong(AlignmentWarEffort);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        AlignmentSide = reader.ReadSByte();
        AlignmentWarEffort = reader.ReadVarULong();
    }
}