using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharactersListMessage : BasicCharactersListMessage
{
    public new const uint Id = 269;

    public CharactersListMessage(IEnumerable<CharacterBaseInformations> characters, bool hasStartupActions)
    {
        Characters = characters;
        HasStartupActions = hasStartupActions;
    }

    public CharactersListMessage()
    {
    }

    public override uint MessageId => Id;

    public bool HasStartupActions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(HasStartupActions);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        HasStartupActions = reader.ReadBoolean();
    }
}