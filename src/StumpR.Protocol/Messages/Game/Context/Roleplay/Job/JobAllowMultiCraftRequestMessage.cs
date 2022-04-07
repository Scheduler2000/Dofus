using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobAllowMultiCraftRequestMessage : Message
{
    public const uint Id = 5111;

    public JobAllowMultiCraftRequestMessage(bool enabled)
    {
        Enabled = enabled;
    }

    public JobAllowMultiCraftRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Enabled { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Enabled);
    }

    public override void Deserialize(IDataReader reader)
    {
        Enabled = reader.ReadBoolean();
    }
}