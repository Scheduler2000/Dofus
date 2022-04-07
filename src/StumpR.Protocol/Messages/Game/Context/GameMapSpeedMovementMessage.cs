using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameMapSpeedMovementMessage : Message
{
    public const uint Id = 8414;

    public GameMapSpeedMovementMessage(int speedMultiplier)
    {
        SpeedMultiplier = speedMultiplier;
    }

    public GameMapSpeedMovementMessage()
    {
    }

    public override uint MessageId => Id;

    public int SpeedMultiplier { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(SpeedMultiplier);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpeedMultiplier = reader.ReadInt();
    }
}