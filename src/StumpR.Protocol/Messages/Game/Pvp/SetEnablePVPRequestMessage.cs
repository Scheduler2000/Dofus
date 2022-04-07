using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SetEnablePVPRequestMessage : Message
{
    public const uint Id = 4228;

    public SetEnablePVPRequestMessage(bool enable)
    {
        Enable = enable;
    }

    public SetEnablePVPRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Enable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Enable);
    }

    public override void Deserialize(IDataReader reader)
    {
        Enable = reader.ReadBoolean();
    }
}