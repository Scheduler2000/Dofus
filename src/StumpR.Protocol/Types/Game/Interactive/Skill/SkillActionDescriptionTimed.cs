using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SkillActionDescriptionTimed : SkillActionDescription
{
    public new const short Id = 9286;

    public SkillActionDescriptionTimed(ushort skillId, byte time)
    {
        SkillId = skillId;
        Time = time;
    }

    public SkillActionDescriptionTimed()
    {
    }

    public override short TypeId => Id;

    public byte Time { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteByte(Time);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Time = reader.ReadByte();
    }
}