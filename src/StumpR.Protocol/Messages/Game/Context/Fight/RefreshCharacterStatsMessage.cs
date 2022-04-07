using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class RefreshCharacterStatsMessage : Message
{
    public const uint Id = 154;

    public RefreshCharacterStatsMessage(double fighterId, GameFightCharacteristics stats)
    {
        FighterId = fighterId;
        Stats = stats;
    }

    public RefreshCharacterStatsMessage()
    {
    }

    public override uint MessageId => Id;

    public double FighterId { get; set; }

    public GameFightCharacteristics Stats { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(FighterId);
        Stats.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FighterId = reader.ReadDouble();
        Stats = new GameFightCharacteristics();
        Stats.Deserialize(reader);
    }
}