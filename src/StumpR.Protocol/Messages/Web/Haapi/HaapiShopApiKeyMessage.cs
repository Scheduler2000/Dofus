using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiShopApiKeyMessage : Message
{
    public const uint Id = 6787;

    public HaapiShopApiKeyMessage(string token)
    {
        Token = token;
    }

    public HaapiShopApiKeyMessage()
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