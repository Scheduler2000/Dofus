using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ForgettableSpellsPreset : Preset
{
    public new const short Id = 8231;

    public ForgettableSpellsPreset(short objectId, SpellsPreset baseSpellsPreset, IEnumerable<SpellForPreset> forgettableSpells)
    {
        ObjectId = objectId;
        BaseSpellsPreset = baseSpellsPreset;
        ForgettableSpells = forgettableSpells;
    }

    public ForgettableSpellsPreset()
    {
    }

    public override short TypeId => Id;

    public SpellsPreset BaseSpellsPreset { get; set; }

    public IEnumerable<SpellForPreset> ForgettableSpells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        BaseSpellsPreset.Serialize(writer);
        writer.WriteShort((short) ForgettableSpells.Count());
        foreach (SpellForPreset objectToSend in ForgettableSpells) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        BaseSpellsPreset = new SpellsPreset();
        BaseSpellsPreset.Deserialize(reader);
        ushort forgettableSpellsCount = reader.ReadUShort();
        var forgettableSpells_ = new SpellForPreset[forgettableSpellsCount];

        for (var forgettableSpellsIndex = 0; forgettableSpellsIndex < forgettableSpellsCount; forgettableSpellsIndex++)
        {
            var objectToAdd = new SpellForPreset();
            objectToAdd.Deserialize(reader);
            forgettableSpells_[forgettableSpellsIndex] = objectToAdd;
        }
        ForgettableSpells = forgettableSpells_;
    }
}