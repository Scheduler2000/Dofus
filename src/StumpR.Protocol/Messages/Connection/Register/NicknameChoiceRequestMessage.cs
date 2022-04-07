using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NicknameChoiceRequestMessage : Message
{
    public const uint Id = 3297;

    public NicknameChoiceRequestMessage(string nickname)
    {
        Nickname = nickname;
    }

    public NicknameChoiceRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Nickname { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Nickname);
    }

    public override void Deserialize(IDataReader reader)
    {
        Nickname = reader.ReadUTF();
    }
}