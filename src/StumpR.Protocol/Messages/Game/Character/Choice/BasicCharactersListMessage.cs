using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicCharactersListMessage : Message
{
    public const uint Id = 8228;

    public BasicCharactersListMessage(IEnumerable<CharacterBaseInformations> characters)
    {
        Characters = characters;
    }

    public BasicCharactersListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<CharacterBaseInformations> Characters { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Characters.Count());

        foreach (CharacterBaseInformations objectToSend in Characters)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort charactersCount = reader.ReadUShort();
        var characters_ = new CharacterBaseInformations[charactersCount];

        for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            characters_[charactersIndex] = objectToAdd;
        }
        Characters = characters_;
    }
}