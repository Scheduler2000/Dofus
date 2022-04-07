using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NicknameRefusedMessage : Message
{
    public const uint Id = 2705;

    public NicknameRefusedMessage(sbyte reason)
    {
        Reason = reason;
    }

    public NicknameRefusedMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
    }
}