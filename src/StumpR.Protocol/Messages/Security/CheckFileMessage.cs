using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CheckFileMessage : Message
{
    public const uint Id = 6281;

    public CheckFileMessage(string filenameHash, sbyte type, string value)
    {
        FilenameHash = filenameHash;
        Type = type;
        Value = value;
    }

    public CheckFileMessage()
    {
    }

    public override uint MessageId => Id;

    public string FilenameHash { get; set; }

    public sbyte Type { get; set; }

    public string Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(FilenameHash);
        writer.WriteSByte(Type);
        writer.WriteUTF(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        FilenameHash = reader.ReadUTF();
        Type = reader.ReadSByte();
        Value = reader.ReadUTF();
    }
}