using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ArenaFighterLeaveMessage : Message
{
    public const uint Id = 1880;

    public ArenaFighterLeaveMessage(CharacterBasicMinimalInformations leaver)
    {
        Leaver = leaver;
    }

    public ArenaFighterLeaveMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterBasicMinimalInformations Leaver { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Leaver.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Leaver = new CharacterBasicMinimalInformations();
        Leaver.Deserialize(reader);
    }
}