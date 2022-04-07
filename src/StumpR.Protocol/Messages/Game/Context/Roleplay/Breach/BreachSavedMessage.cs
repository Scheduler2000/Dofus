using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachSavedMessage : Message
{
    public const uint Id = 4537;

    public BreachSavedMessage(bool saved)
    {
        Saved = saved;
    }

    public BreachSavedMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Saved { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Saved);
    }

    public override void Deserialize(IDataReader reader)
    {
        Saved = reader.ReadBoolean();
    }
}