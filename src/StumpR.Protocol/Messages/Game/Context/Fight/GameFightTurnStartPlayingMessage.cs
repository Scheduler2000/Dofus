using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightTurnStartPlayingMessage : Message
{
    public const uint Id = 3275;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}