using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightTurnReadyMessage : Message
{
    public const uint Id = 4043;

    public GameFightTurnReadyMessage(bool isReady)
    {
        IsReady = isReady;
    }

    public GameFightTurnReadyMessage()
    {
    }

    public override uint MessageId => Id;

    public bool IsReady { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(IsReady);
    }

    public override void Deserialize(IDataReader reader)
    {
        IsReady = reader.ReadBoolean();
    }
}