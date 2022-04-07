using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ResetCharacterStatsRequestMessage : Message
{
    public const uint Id = 9708;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}