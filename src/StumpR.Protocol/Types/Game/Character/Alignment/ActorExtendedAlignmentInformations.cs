using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ActorExtendedAlignmentInformations : ActorAlignmentInformations
{
    public new const short Id = 4302;

    public ActorExtendedAlignmentInformations(sbyte alignmentSide,
        sbyte alignmentValue,
        sbyte alignmentGrade,
        double characterPower,
        ushort honor,
        ushort honorGradeFloor,
        ushort honorNextGradeFloor,
        sbyte aggressable)
    {
        AlignmentSide = alignmentSide;
        AlignmentValue = alignmentValue;
        AlignmentGrade = alignmentGrade;
        CharacterPower = characterPower;
        Honor = honor;
        HonorGradeFloor = honorGradeFloor;
        HonorNextGradeFloor = honorNextGradeFloor;
        Aggressable = aggressable;
    }

    public ActorExtendedAlignmentInformations()
    {
    }

    public override short TypeId => Id;

    public ushort Honor { get; set; }

    public ushort HonorGradeFloor { get; set; }

    public ushort HonorNextGradeFloor { get; set; }

    public sbyte Aggressable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Honor);
        writer.WriteVarUShort(HonorGradeFloor);
        writer.WriteVarUShort(HonorNextGradeFloor);
        writer.WriteSByte(Aggressable);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Honor = reader.ReadVarUShort();
        HonorGradeFloor = reader.ReadVarUShort();
        HonorNextGradeFloor = reader.ReadVarUShort();
        Aggressable = reader.ReadSByte();
    }
}