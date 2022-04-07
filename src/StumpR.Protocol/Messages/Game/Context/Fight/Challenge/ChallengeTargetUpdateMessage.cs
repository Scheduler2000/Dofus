using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChallengeTargetUpdateMessage : Message
{
    public const uint Id = 1613;

    public ChallengeTargetUpdateMessage(ushort challengeId, double targetId)
    {
        ChallengeId = challengeId;
        TargetId = targetId;
    }

    public ChallengeTargetUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ChallengeId { get; set; }

    public double TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ChallengeId);
        writer.WriteDouble(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ChallengeId = reader.ReadVarUShort();
        TargetId = reader.ReadDouble();
    }
}