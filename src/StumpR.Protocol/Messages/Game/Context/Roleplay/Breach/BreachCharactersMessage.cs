using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachCharactersMessage : Message
{
    public const uint Id = 6300;

    public BreachCharactersMessage(IEnumerable<ulong> characters)
    {
        Characters = characters;
    }

    public BreachCharactersMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ulong> Characters { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Characters.Count());
        foreach (ulong objectToSend in Characters) writer.WriteVarULong(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort charactersCount = reader.ReadUShort();
        var characters_ = new ulong[charactersCount];

        for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
            characters_[charactersIndex] = reader.ReadVarULong();
        Characters = characters_;
    }
}