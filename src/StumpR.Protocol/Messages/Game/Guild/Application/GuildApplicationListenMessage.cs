using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildApplicationListenMessage : Message
{
    public const uint Id = 9375;

    public GuildApplicationListenMessage(bool listen)
    {
        Listen = listen;
    }

    public GuildApplicationListenMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Listen { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Listen);
    }

    public override void Deserialize(IDataReader reader)
    {
        Listen = reader.ReadBoolean();
    }
}