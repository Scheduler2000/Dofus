using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChallengeTargetsListRequestMessage : Message
{
    public const uint Id = 8411;

    public ChallengeTargetsListRequestMessage(ushort challengeId)
    {
        ChallengeId = challengeId;
    }

    public ChallengeTargetsListRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ChallengeId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ChallengeId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ChallengeId = reader.ReadVarUShort();
    }
}