using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeStartOkJobIndexMessage : Message
{
    public const uint Id = 1146;

    public ExchangeStartOkJobIndexMessage(IEnumerable<uint> jobs)
    {
        Jobs = jobs;
    }

    public ExchangeStartOkJobIndexMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> Jobs { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Jobs.Count());
        foreach (uint objectToSend in Jobs) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort jobsCount = reader.ReadUShort();
        var jobs_ = new uint[jobsCount];
        for (var jobsIndex = 0; jobsIndex < jobsCount; jobsIndex++) jobs_[jobsIndex] = reader.ReadVarUInt();
        Jobs = jobs_;
    }
}