using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LockableChangeCodeMessage : Message
{
    public const uint Id = 768;

    public LockableChangeCodeMessage(string code)
    {
        Code = code;
    }

    public LockableChangeCodeMessage()
    {
    }

    public override uint MessageId => Id;

    public string Code { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Code);
    }

    public override void Deserialize(IDataReader reader)
    {
        Code = reader.ReadUTF();
    }
}