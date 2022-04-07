using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiSessionMessage : Message
{
    public const uint Id = 5486;

    public HaapiSessionMessage(string key, sbyte type)
    {
        Key = key;
        Type = type;
    }

    public HaapiSessionMessage()
    {
    }

    public override uint MessageId => Id;

    public string Key { get; set; }

    public sbyte Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Key);
        writer.WriteSByte(Type);
    }

    public override void Deserialize(IDataReader reader)
    {
        Key = reader.ReadUTF();
        Type = reader.ReadSByte();
    }
}