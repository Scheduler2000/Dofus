using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LockableStateUpdateAbstractMessage : Message
{
    public const uint Id = 5676;

    public LockableStateUpdateAbstractMessage(bool locked)
    {
        Locked = locked;
    }

    public LockableStateUpdateAbstractMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Locked { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Locked);
    }

    public override void Deserialize(IDataReader reader)
    {
        Locked = reader.ReadBoolean();
    }
}