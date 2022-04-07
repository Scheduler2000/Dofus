using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StatsUpgradeRequestMessage : Message
{
    public const uint Id = 327;

    public StatsUpgradeRequestMessage(bool useAdditionnal, sbyte statId, ushort boostPoint)
    {
        UseAdditionnal = useAdditionnal;
        StatId = statId;
        BoostPoint = boostPoint;
    }

    public StatsUpgradeRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool UseAdditionnal { get; set; }

    public sbyte StatId { get; set; }

    public ushort BoostPoint { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(UseAdditionnal);
        writer.WriteSByte(StatId);
        writer.WriteVarUShort(BoostPoint);
    }

    public override void Deserialize(IDataReader reader)
    {
        UseAdditionnal = reader.ReadBoolean();
        StatId = reader.ReadSByte();
        BoostPoint = reader.ReadVarUShort();
    }
}