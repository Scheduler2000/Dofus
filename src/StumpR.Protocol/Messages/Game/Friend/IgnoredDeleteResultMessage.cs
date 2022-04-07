using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IgnoredDeleteResultMessage : Message
{
    public const uint Id = 9652;

    public IgnoredDeleteResultMessage(bool success, bool session, AccountTagInformation tag)
    {
        Success = success;
        Session = session;
        Tag = tag;
    }

    public IgnoredDeleteResultMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Success { get; set; }

    public bool Session { get; set; }

    public AccountTagInformation Tag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Success);
        flag = BooleanByteWrapper.SetFlag(flag, 1, Session);
        writer.WriteByte(flag);
        Tag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Success = BooleanByteWrapper.GetFlag(flag, 0);
        Session = BooleanByteWrapper.GetFlag(flag, 1);
        Tag = new AccountTagInformation();
        Tag.Deserialize(reader);
    }
}