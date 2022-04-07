using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightNoSpellCastMessage : Message
{
    public const uint Id = 8111;

    public GameActionFightNoSpellCastMessage(uint spellLevelId)
    {
        SpellLevelId = spellLevelId;
    }

    public GameActionFightNoSpellCastMessage()
    {
    }

    public override uint MessageId => Id;

    public uint SpellLevelId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(SpellLevelId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellLevelId = reader.ReadVarUInt();
    }
}