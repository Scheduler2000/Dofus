using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class SpellsPreset : Preset
{
    public new const short Id = 1337;

    public SpellsPreset(short objectId, IEnumerable<SpellForPreset> spells)
    {
        ObjectId = objectId;
        Spells = spells;
    }

    public SpellsPreset()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<SpellForPreset> Spells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Spells.Count());
        foreach (SpellForPreset objectToSend in Spells) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort spellsCount = reader.ReadUShort();
        var spells_ = new SpellForPreset[spellsCount];

        for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
        {
            var objectToAdd = new SpellForPreset();
            objectToAdd.Deserialize(reader);
            spells_[spellsIndex] = objectToAdd;
        }
        Spells = spells_;
    }
}