using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportBuddiesAnswerMessage : Message
{
    public const uint Id = 3499;

    public TeleportBuddiesAnswerMessage(bool accept)
    {
        Accept = accept;
    }

    public TeleportBuddiesAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Accept { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(IDataReader reader)
    {
        Accept = reader.ReadBoolean();
    }
}