using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionSkillUse : HumanOption
{
    public new const short Id = 2427;

    public HumanOptionSkillUse(uint elementId, ushort skillId, double skillEndTime)
    {
        ElementId = elementId;
        SkillId = skillId;
        SkillEndTime = skillEndTime;
    }

    public HumanOptionSkillUse()
    {
    }

    public override short TypeId => Id;

    public uint ElementId { get; set; }

    public ushort SkillId { get; set; }

    public double SkillEndTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(ElementId);
        writer.WriteVarUShort(SkillId);
        writer.WriteDouble(SkillEndTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ElementId = reader.ReadVarUInt();
        SkillId = reader.ReadVarUShort();
        SkillEndTime = reader.ReadDouble();
    }
}