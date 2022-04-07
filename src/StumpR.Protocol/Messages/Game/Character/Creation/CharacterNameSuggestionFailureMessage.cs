using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterNameSuggestionFailureMessage : Message
{
    public const uint Id = 3074;

    public CharacterNameSuggestionFailureMessage(sbyte reason)
    {
        Reason = reason;
    }

    public CharacterNameSuggestionFailureMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
    }
}