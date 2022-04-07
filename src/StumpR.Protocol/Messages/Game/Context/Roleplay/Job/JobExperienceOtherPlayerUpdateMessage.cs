using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobExperienceOtherPlayerUpdateMessage : JobExperienceUpdateMessage
{
    public new const uint Id = 5477;

    public JobExperienceOtherPlayerUpdateMessage(JobExperience experiencesUpdate, ulong playerId)
    {
        ExperiencesUpdate = experiencesUpdate;
        PlayerId = playerId;
    }

    public JobExperienceOtherPlayerUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
    }
}