using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachExitResponseMessage : Message
{
    public const uint Id = 7143;

    public BreachExitResponseMessage(bool exited)
    {
        Exited = exited;
    }

    public BreachExitResponseMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Exited { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Exited);
    }

    public override void Deserialize(IDataReader reader)
    {
        Exited = reader.ReadBoolean();
    }
}