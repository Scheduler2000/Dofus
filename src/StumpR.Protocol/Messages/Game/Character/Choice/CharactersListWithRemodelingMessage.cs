using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharactersListWithRemodelingMessage : CharactersListMessage
{
    public new const uint Id = 3532;

    public CharactersListWithRemodelingMessage(IEnumerable<CharacterBaseInformations> characters,
        bool hasStartupActions,
        IEnumerable<CharacterToRemodelInformations> charactersToRemodel)
    {
        Characters = characters;
        HasStartupActions = hasStartupActions;
        CharactersToRemodel = charactersToRemodel;
    }

    public CharactersListWithRemodelingMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<CharacterToRemodelInformations> CharactersToRemodel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) CharactersToRemodel.Count());
        foreach (CharacterToRemodelInformations objectToSend in CharactersToRemodel) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort charactersToRemodelCount = reader.ReadUShort();
        var charactersToRemodel_ = new CharacterToRemodelInformations[charactersToRemodelCount];

        for (var charactersToRemodelIndex = 0; charactersToRemodelIndex < charactersToRemodelCount; charactersToRemodelIndex++)
        {
            var objectToAdd = new CharacterToRemodelInformations();
            objectToAdd.Deserialize(reader);
            charactersToRemodel_[charactersToRemodelIndex] = objectToAdd;
        }
        CharactersToRemodel = charactersToRemodel_;
    }
}