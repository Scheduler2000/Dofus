using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterCanBeCreatedResultMessage : Message
{
    public const uint Id = 9527;

    public CharacterCanBeCreatedResultMessage(bool yesYouCan)
    {
        YesYouCan = yesYouCan;
    }

    public CharacterCanBeCreatedResultMessage()
    {
    }

    public override uint MessageId => Id;

    public bool YesYouCan { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(YesYouCan);
    }

    public override void Deserialize(IDataReader reader)
    {
        YesYouCan = reader.ReadBoolean();
    }
}