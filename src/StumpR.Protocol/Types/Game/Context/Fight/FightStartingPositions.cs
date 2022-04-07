using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightStartingPositions
{
    public const short Id = 9707;

    public FightStartingPositions(IEnumerable<ushort> positionsForChallengers, IEnumerable<ushort> positionsForDefenders)
    {
        PositionsForChallengers = positionsForChallengers;
        PositionsForDefenders = positionsForDefenders;
    }

    public FightStartingPositions()
    {
    }

    public virtual short TypeId => Id;

    public IEnumerable<ushort> PositionsForChallengers { get; set; }

    public IEnumerable<ushort> PositionsForDefenders { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PositionsForChallengers.Count());
        foreach (ushort objectToSend in PositionsForChallengers) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) PositionsForDefenders.Count());
        foreach (ushort objectToSend in PositionsForDefenders) writer.WriteVarUShort(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ushort positionsForChallengersCount = reader.ReadUShort();
        var positionsForChallengers_ = new ushort[positionsForChallengersCount];

        for (var positionsForChallengersIndex = 0;
             positionsForChallengersIndex < positionsForChallengersCount;
             positionsForChallengersIndex++)
            positionsForChallengers_[positionsForChallengersIndex] = reader.ReadVarUShort();
        PositionsForChallengers = positionsForChallengers_;
        ushort positionsForDefendersCount = reader.ReadUShort();
        var positionsForDefenders_ = new ushort[positionsForDefendersCount];

        for (var positionsForDefendersIndex = 0; positionsForDefendersIndex < positionsForDefendersCount; positionsForDefendersIndex++)
            positionsForDefenders_[positionsForDefendersIndex] = reader.ReadVarUShort();
        PositionsForDefenders = positionsForDefenders_;
    }
}