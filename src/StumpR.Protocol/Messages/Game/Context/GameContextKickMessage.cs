using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextKickMessage : Message
{
    public const uint Id = 2712;

    public GameContextKickMessage(double targetId)
    {
        TargetId = targetId;
    }

    public GameContextKickMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TargetId = reader.ReadDouble();
    }
}