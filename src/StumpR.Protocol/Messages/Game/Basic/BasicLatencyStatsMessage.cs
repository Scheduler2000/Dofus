using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicLatencyStatsMessage : Message
{
    public const uint Id = 3831;

    public BasicLatencyStatsMessage(ushort latency, ushort sampleCount, ushort max)
    {
        Latency = latency;
        SampleCount = sampleCount;
        Max = max;
    }

    public BasicLatencyStatsMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Latency { get; set; }

    public ushort SampleCount { get; set; }

    public ushort Max { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUShort(Latency);
        writer.WriteVarUShort(SampleCount);
        writer.WriteVarUShort(Max);
    }

    public override void Deserialize(IDataReader reader)
    {
        Latency = reader.ReadUShort();
        SampleCount = reader.ReadVarUShort();
        Max = reader.ReadVarUShort();
    }
}