using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightReadyMessage : Message
{
    public const uint Id = 3480;

    public GameFightReadyMessage(bool isReady)
    {
        IsReady = isReady;
    }

    public GameFightReadyMessage()
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