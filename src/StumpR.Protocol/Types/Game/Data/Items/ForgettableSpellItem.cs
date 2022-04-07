using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ForgettableSpellItem : SpellItem
{
    public new const short Id = 2497;

    public ForgettableSpellItem(int spellId, short spellLevel, bool available)
    {
        SpellId = spellId;
        SpellLevel = spellLevel;
        Available = available;
    }

    public ForgettableSpellItem()
    {
    }

    public override short TypeId => Id;

    public bool Available { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(Available);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Available = reader.ReadBoolean();
    }
}