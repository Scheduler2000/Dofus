using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class InteractiveElementNamedSkill : InteractiveElementSkill
{
    public new const short Id = 3340;

    public InteractiveElementNamedSkill(uint skillId, int skillInstanceUid, uint nameId)
    {
        SkillId = skillId;
        SkillInstanceUid = skillInstanceUid;
        NameId = nameId;
    }

    public InteractiveElementNamedSkill()
    {
    }

    public override short TypeId => Id;

    public uint NameId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(NameId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        NameId = reader.ReadVarUInt();
    }
}