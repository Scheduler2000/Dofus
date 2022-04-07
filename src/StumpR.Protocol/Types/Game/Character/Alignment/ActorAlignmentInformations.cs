using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ActorAlignmentInformations
{
    public const short Id = 3635;

    public ActorAlignmentInformations(sbyte alignmentSide, sbyte alignmentValue, sbyte alignmentGrade, double characterPower)
    {
        AlignmentSide = alignmentSide;
        AlignmentValue = alignmentValue;
        AlignmentGrade = alignmentGrade;
        CharacterPower = characterPower;
    }

    public ActorAlignmentInformations()
    {
    }

    public virtual short TypeId => Id;

    public sbyte AlignmentSide { get; set; }

    public sbyte AlignmentValue { get; set; }

    public sbyte AlignmentGrade { get; set; }

    public double CharacterPower { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(AlignmentSide);
        writer.WriteSByte(AlignmentValue);
        writer.WriteSByte(AlignmentGrade);
        writer.WriteDouble(CharacterPower);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        AlignmentSide = reader.ReadSByte();
        AlignmentValue = reader.ReadSByte();
        AlignmentGrade = reader.ReadSByte();
        CharacterPower = reader.ReadDouble();
    }
}