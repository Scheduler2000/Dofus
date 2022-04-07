using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicLatencyStatsRequestMessage : Message
{
    public const uint Id = 1245;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}