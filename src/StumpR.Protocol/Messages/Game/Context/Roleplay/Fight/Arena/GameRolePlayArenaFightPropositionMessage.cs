using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaFightPropositionMessage : Message
{
    public const uint Id = 2533;

    public GameRolePlayArenaFightPropositionMessage(ushort fightId, IEnumerable<double> alliesId, ushort duration)
    {
        FightId = fightId;
        AlliesId = alliesId;
        Duration = duration;
    }

    public GameRolePlayArenaFightPropositionMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public IEnumerable<double> AlliesId { get; set; }

    public ushort Duration { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteShort((short) AlliesId.Count());
        foreach (double objectToSend in AlliesId) writer.WriteDouble(objectToSend);
        writer.WriteVarUShort(Duration);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        ushort alliesIdCount = reader.ReadUShort();
        var alliesId_ = new double[alliesIdCount];
        for (var alliesIdIndex = 0; alliesIdIndex < alliesIdCount; alliesIdIndex++) alliesId_[alliesIdIndex] = reader.ReadDouble();
        AlliesId = alliesId_;
        Duration = reader.ReadVarUShort();
    }
}