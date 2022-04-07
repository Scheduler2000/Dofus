using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightNewWaveMessage : Message
{
    public const uint Id = 1312;

    public GameFightNewWaveMessage(sbyte objectId, sbyte teamId, short nbTurnBeforeNextWave)
    {
        ObjectId = objectId;
        TeamId = teamId;
        NbTurnBeforeNextWave = nbTurnBeforeNextWave;
    }

    public GameFightNewWaveMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ObjectId { get; set; }

    public sbyte TeamId { get; set; }

    public short NbTurnBeforeNextWave { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ObjectId);
        writer.WriteSByte(TeamId);
        writer.WriteShort(NbTurnBeforeNextWave);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadSByte();
        TeamId = reader.ReadSByte();
        NbTurnBeforeNextWave = reader.ReadShort();
    }
}