using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class JobDescription
{
    public const short Id = 2005;

    public JobDescription(sbyte jobId, IEnumerable<SkillActionDescription> skills)
    {
        JobId = jobId;
        Skills = skills;
    }

    public JobDescription()
    {
    }

    public virtual short TypeId => Id;

    public sbyte JobId { get; set; }

    public IEnumerable<SkillActionDescription> Skills { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(JobId);
        writer.WriteShort((short) Skills.Count());

        foreach (SkillActionDescription objectToSend in Skills)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        JobId = reader.ReadSByte();
        ushort skillsCount = reader.ReadUShort();
        var skills_ = new SkillActionDescription[skillsCount];

        for (var skillsIndex = 0; skillsIndex < skillsCount; skillsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<SkillActionDescription>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            skills_[skillsIndex] = objectToAdd;
        }
        Skills = skills_;
    }
}