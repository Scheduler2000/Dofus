using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightPlacementPossiblePositionsMessage : Message
{
    public const uint Id = 3019;

    public GameFightPlacementPossiblePositionsMessage(IEnumerable<ushort> positionsForChallengers,
        IEnumerable<ushort> positionsForDefenders,
        sbyte teamNumber)
    {
        PositionsForChallengers = positionsForChallengers;
        PositionsForDefenders = positionsForDefenders;
        TeamNumber = teamNumber;
    }

    public GameFightPlacementPossiblePositionsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> PositionsForChallengers { get; set; }

    public IEnumerable<ushort> PositionsForDefenders { get; set; }

    public sbyte TeamNumber { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PositionsForChallengers.Count());
        foreach (ushort objectToSend in PositionsForChallengers) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) PositionsForDefenders.Count());
        foreach (ushort objectToSend in PositionsForDefenders) writer.WriteVarUShort(objectToSend);
        writer.WriteSByte(TeamNumber);
    }

    public override void Deserialize(IDataReader reader)
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
        TeamNumber = reader.ReadSByte();
    }
}