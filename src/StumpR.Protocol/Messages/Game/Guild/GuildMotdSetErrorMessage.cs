using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildMotdSetErrorMessage : SocialNoticeSetErrorMessage
{
    public new const uint Id = 1049;

    public GuildMotdSetErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public GuildMotdSetErrorMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}