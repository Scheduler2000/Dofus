using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightResultPvpData : FightResultAdditionalData
{
    public new const short Id = 9919;

    public FightResultPvpData(byte grade, ushort minHonorForGrade, ushort maxHonorForGrade, ushort honor, short honorDelta)
    {
        Grade = grade;
        MinHonorForGrade = minHonorForGrade;
        MaxHonorForGrade = maxHonorForGrade;
        Honor = honor;
        HonorDelta = honorDelta;
    }

    public FightResultPvpData()
    {
    }

    public override short TypeId => Id;

    public byte Grade { get; set; }

    public ushort MinHonorForGrade { get; set; }

    public ushort MaxHonorForGrade { get; set; }

    public ushort Honor { get; set; }

    public short HonorDelta { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteByte(Grade);
        writer.WriteVarUShort(MinHonorForGrade);
        writer.WriteVarUShort(MaxHonorForGrade);
        writer.WriteVarUShort(Honor);
        writer.WriteVarShort(HonorDelta);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Grade = reader.ReadByte();
        MinHonorForGrade = reader.ReadVarUShort();
        MaxHonorForGrade = reader.ReadVarUShort();
        Honor = reader.ReadVarUShort();
        HonorDelta = reader.ReadVarShort();
    }
}