using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayDelayedActionFinishedMessage : Message
{
    public const uint Id = 6062;

    public GameRolePlayDelayedActionFinishedMessage(double delayedCharacterId, sbyte delayTypeId)
    {
        DelayedCharacterId = delayedCharacterId;
        DelayTypeId = delayTypeId;
    }

    public GameRolePlayDelayedActionFinishedMessage()
    {
    }

    public override uint MessageId => Id;

    public double DelayedCharacterId { get; set; }

    public sbyte DelayTypeId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(DelayedCharacterId);
        writer.WriteSByte(DelayTypeId);
    }

    public override void Deserialize(IDataReader reader)
    {
        DelayedCharacterId = reader.ReadDouble();
        DelayTypeId = reader.ReadSByte();
    }
}