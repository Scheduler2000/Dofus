using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiApiKeyMessage : Message
{
    public const uint Id = 9970;

    public HaapiApiKeyMessage(string token)
    {
        Token = token;
    }

    public HaapiApiKeyMessage()
    {
    }

    public override uint MessageId => Id;

    public string Token { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Token);
    }

    public override void Deserialize(IDataReader reader)
    {
        Token = reader.ReadUTF();
    }
}