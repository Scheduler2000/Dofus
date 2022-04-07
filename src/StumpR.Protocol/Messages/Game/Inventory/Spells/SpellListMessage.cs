using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SpellListMessage : Message
{
    public const uint Id = 4091;

    public SpellListMessage(bool spellPrevisualization, IEnumerable<SpellItem> spells)
    {
        SpellPrevisualization = spellPrevisualization;
        Spells = spells;
    }

    public SpellListMessage()
    {
    }

    public override uint MessageId => Id;

    public bool SpellPrevisualization { get; set; }

    public IEnumerable<SpellItem> Spells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(SpellPrevisualization);
        writer.WriteShort((short) Spells.Count());
        foreach (SpellItem objectToSend in Spells) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        SpellPrevisualization = reader.ReadBoolean();
        ushort spellsCount = reader.ReadUShort();
        var spells_ = new SpellItem[spellsCount];

        for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
        {
            var objectToAdd = new SpellItem();
            objectToAdd.Deserialize(reader);
            spells_[spellsIndex] = objectToAdd;
        }
        Spells = spells_;
    }
}