using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeReplayStopMessage : Message
{
    public const uint Id = 6235;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}