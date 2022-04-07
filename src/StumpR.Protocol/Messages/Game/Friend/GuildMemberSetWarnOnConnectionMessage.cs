using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildMemberSetWarnOnConnectionMessage : Message
{
    public const uint Id = 4147;

    public GuildMemberSetWarnOnConnectionMessage(bool enable)
    {
        Enable = enable;
    }

    public GuildMemberSetWarnOnConnectionMessage()
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