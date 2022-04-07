using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightNewRoundMessage : Message
{
    public const uint Id = 1656;

    public GameFightNewRoundMessage(uint roundNumber)
    {
        RoundNumber = roundNumber;
    }

    public GameFightNewRoundMessage()
    {
    }

    public override uint MessageId => Id;

    public uint RoundNumber { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(RoundNumber);
    }

    public override void Deserialize(IDataReader reader)
    {
        RoundNumber = reader.ReadVarUInt();
    }
}