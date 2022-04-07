using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobBookSubscribeRequestMessage : Message
{
    public const uint Id = 4809;

    public JobBookSubscribeRequestMessage(IEnumerable<byte> jobIds)
    {
        JobIds = jobIds;
    }

    public JobBookSubscribeRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<byte> JobIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) JobIds.Count());
        foreach (byte objectToSend in JobIds) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort jobIdsCount = reader.ReadUShort();
        var jobIds_ = new byte[jobIdsCount];
        for (var jobIdsIndex = 0; jobIdsIndex < jobIdsCount; jobIdsIndex++) jobIds_[jobIdsIndex] = reader.ReadByte();
        JobIds = jobIds_;
    }
}