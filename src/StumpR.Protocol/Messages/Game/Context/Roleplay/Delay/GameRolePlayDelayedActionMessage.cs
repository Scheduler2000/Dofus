using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayDelayedActionMessage : Message
{
    public const uint Id = 1161;

    public GameRolePlayDelayedActionMessage(double delayedCharacterId, sbyte delayTypeId, double delayEndTime)
    {
        DelayedCharacterId = delayedCharacterId;
        DelayTypeId = delayTypeId;
        DelayEndTime = delayEndTime;
    }

    public GameRolePlayDelayedActionMessage()
    {
    }

    public override uint MessageId => Id;

    public double DelayedCharacterId { get; set; }

    public sbyte DelayTypeId { get; set; }

    public double DelayEndTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(DelayedCharacterId);
        writer.WriteSByte(DelayTypeId);
        writer.WriteDouble(DelayEndTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        DelayedCharacterId = reader.ReadDouble();
        DelayTypeId = reader.ReadSByte();
        DelayEndTime = reader.ReadDouble();
    }
}