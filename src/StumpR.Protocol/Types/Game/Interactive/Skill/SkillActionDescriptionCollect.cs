using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SkillActionDescriptionCollect : SkillActionDescriptionTimed
{
    public new const short Id = 5191;

    public SkillActionDescriptionCollect(ushort skillId, byte time, ushort min, ushort max)
    {
        SkillId = skillId;
        Time = time;
        Min = min;
        Max = max;
    }

    public SkillActionDescriptionCollect()
    {
    }

    public override short TypeId => Id;

    public ushort Min { get; set; }

    public ushort Max { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Min);
        writer.WriteVarUShort(Max);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Min = reader.ReadVarUShort();
        Max = reader.ReadVarUShort();
    }
}