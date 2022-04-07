using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChallengeInfoMessage : Message
{
    public const uint Id = 638;

    public ChallengeInfoMessage(ushort challengeId, double targetId, uint xpBonus, uint dropBonus)
    {
        ChallengeId = challengeId;
        TargetId = targetId;
        XpBonus = xpBonus;
        DropBonus = dropBonus;
    }

    public ChallengeInfoMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ChallengeId { get; set; }

    public double TargetId { get; set; }

    public uint XpBonus { get; set; }

    public uint DropBonus { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ChallengeId);
        writer.WriteDouble(TargetId);
        writer.WriteVarUInt(XpBonus);
        writer.WriteVarUInt(DropBonus);
    }

    public override void Deserialize(IDataReader reader)
    {
        ChallengeId = reader.ReadVarUShort();
        TargetId = reader.ReadDouble();
        XpBonus = reader.ReadVarUInt();
        DropBonus = reader.ReadVarUInt();
    }
}