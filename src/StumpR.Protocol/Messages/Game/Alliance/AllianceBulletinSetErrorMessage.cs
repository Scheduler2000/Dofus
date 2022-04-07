using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceBulletinSetErrorMessage : SocialNoticeSetErrorMessage
{
    public new const uint Id = 9529;

    public AllianceBulletinSetErrorMessage(sbyte reason)
    {
        Reason = reason;
    }

    public AllianceBulletinSetErrorMessage()
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