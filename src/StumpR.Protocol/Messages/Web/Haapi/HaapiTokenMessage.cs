using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiTokenMessage : Message
{
    public const uint Id = 8938;

    public HaapiTokenMessage(string token)
    {
        Token = token;
    }

    public HaapiTokenMessage()
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