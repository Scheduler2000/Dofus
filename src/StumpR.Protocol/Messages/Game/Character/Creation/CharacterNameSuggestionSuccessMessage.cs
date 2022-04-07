using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterNameSuggestionSuccessMessage : Message
{
    public const uint Id = 428;

    public CharacterNameSuggestionSuccessMessage(string suggestion)
    {
        Suggestion = suggestion;
    }

    public CharacterNameSuggestionSuccessMessage()
    {
    }

    public override uint MessageId => Id;

    public string Suggestion { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Suggestion);
    }

    public override void Deserialize(IDataReader reader)
    {
        Suggestion = reader.ReadUTF();
    }
}