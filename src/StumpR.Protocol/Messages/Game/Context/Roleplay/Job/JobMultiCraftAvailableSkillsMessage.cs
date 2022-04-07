using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobMultiCraftAvailableSkillsMessage : JobAllowMultiCraftRequestMessage
{
    public new const uint Id = 1246;

    public JobMultiCraftAvailableSkillsMessage(bool enabled, ulong playerId, IEnumerable<ushort> skills)
    {
        Enabled = enabled;
        PlayerId = playerId;
        Skills = skills;
    }

    public JobMultiCraftAvailableSkillsMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public IEnumerable<ushort> Skills { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
        writer.WriteShort((short) Skills.Count());
        foreach (ushort objectToSend in Skills) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
        ushort skillsCount = reader.ReadUShort();
        var skills_ = new ushort[skillsCount];
        for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++) skills_[skillsIndex] = reader.ReadVarUShort();
        Skills = skills_;
    }
}