using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HelloConnectMessage : Message
{
    public const uint Id = 6739;

    public HelloConnectMessage(string salt, IEnumerable<sbyte> key)
    {
        Salt = salt;
        Key = key;
    }

    public HelloConnectMessage()
    {
    }

    public override uint MessageId => Id;

    public string Salt { get; set; }

    public IEnumerable<sbyte> Key { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Salt);
        writer.WriteVarInt(Key.Count());
        foreach (sbyte objectToSend in Key) writer.WriteSByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        Salt = reader.ReadUTF();
        int keyCount = reader.ReadVarInt();
        var key_ = new sbyte[keyCount];
        for (var keyIndex = 0; keyIndex < keyCount; keyIndex++) key_[keyIndex] = reader.ReadSByte();
        Key = key_;
    }
}