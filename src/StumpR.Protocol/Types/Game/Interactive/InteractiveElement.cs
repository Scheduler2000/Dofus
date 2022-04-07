using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class InteractiveElement
{
    public const short Id = 4768;

    public InteractiveElement(int elementId,
        int elementTypeId,
        IEnumerable<InteractiveElementSkill> enabledSkills,
        IEnumerable<InteractiveElementSkill> disabledSkills,
        bool onCurrentMap)
    {
        ElementId = elementId;
        ElementTypeId = elementTypeId;
        EnabledSkills = enabledSkills;
        DisabledSkills = disabledSkills;
        OnCurrentMap = onCurrentMap;
    }

    public InteractiveElement()
    {
    }

    public virtual short TypeId => Id;

    public int ElementId { get; set; }

    public int ElementTypeId { get; set; }

    public IEnumerable<InteractiveElementSkill> EnabledSkills { get; set; }

    public IEnumerable<InteractiveElementSkill> DisabledSkills { get; set; }

    public bool OnCurrentMap { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ElementId);
        writer.WriteInt(ElementTypeId);
        writer.WriteShort((short) EnabledSkills.Count());

        foreach (InteractiveElementSkill objectToSend in EnabledSkills)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) DisabledSkills.Count());

        foreach (InteractiveElementSkill objectToSend in DisabledSkills)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteBoolean(OnCurrentMap);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ElementId = reader.ReadInt();
        ElementTypeId = reader.ReadInt();
        ushort enabledSkillsCount = reader.ReadUShort();
        var enabledSkills_ = new InteractiveElementSkill[enabledSkillsCount];

        for (var enabledSkillsIndex = 0; enabledSkillsIndex < enabledSkillsCount; enabledSkillsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            enabledSkills_[enabledSkillsIndex] = objectToAdd;
        }
        EnabledSkills = enabledSkills_;
        ushort disabledSkillsCount = reader.ReadUShort();
        var disabledSkills_ = new InteractiveElementSkill[disabledSkillsCount];

        for (var disabledSkillsIndex = 0; disabledSkillsIndex < disabledSkillsCount; disabledSkillsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElementSkill>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            disabledSkills_[disabledSkillsIndex] = objectToAdd;
        }
        DisabledSkills = disabledSkills_;
        OnCurrentMap = reader.ReadBoolean();
    }
}