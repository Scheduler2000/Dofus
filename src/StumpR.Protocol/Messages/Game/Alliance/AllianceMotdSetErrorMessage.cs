using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceMotdSetErrorMessage : SocialNoticeSetErrorMessage
{
    public new const uint Id = 9723;

    public AllianceMotdSetErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public AllianceMotdSetErrorMessage()
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