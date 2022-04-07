using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CheckFileRequestMessage : Message
{
    public const uint Id = 7075;

    public CheckFileRequestMessage(string filename, sbyte type)
    {
        Filename = filename;
        Type = type;
    }

    public CheckFileRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Filename { get; set; }

    public sbyte Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Filename);
        writer.WriteSByte(Type);
    }

    public override void Deserialize(IDataReader reader)
    {
        Filename = reader.ReadUTF();
        Type = reader.ReadSByte();
    }
}