using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SlaveSwitchContextMessage : Message
{
    public const uint Id = 6013;

    public SlaveSwitchContextMessage(double masterId,
        double slaveId,
        ushort slaveTurn,
        IEnumerable<SpellItem> slaveSpells,
        CharacterCharacteristicsInformations slaveStats,
        IEnumerable<Shortcut> shortcuts)
    {
        MasterId = masterId;
        SlaveId = slaveId;
        SlaveTurn = slaveTurn;
        SlaveSpells = slaveSpells;
        SlaveStats = slaveStats;
        Shortcuts = shortcuts;
    }

    public SlaveSwitchContextMessage()
    {
    }

    public override uint MessageId => Id;

    public double MasterId { get; set; }

    public double SlaveId { get; set; }

    public ushort SlaveTurn { get; set; }

    public IEnumerable<SpellItem> SlaveSpells { get; set; }

    public CharacterCharacteristicsInformations SlaveStats { get; set; }

    public IEnumerable<Shortcut> Shortcuts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MasterId);
        writer.WriteDouble(SlaveId);
        writer.WriteVarUShort(SlaveTurn);
        writer.WriteShort((short) SlaveSpells.Count());
        foreach (SpellItem objectToSend in SlaveSpells) objectToSend.Serialize(writer);
        SlaveStats.Serialize(writer);
        writer.WriteShort((short) Shortcuts.Count());

        foreach (Shortcut objectToSend in Shortcuts)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        MasterId = reader.ReadDouble();
        SlaveId = reader.ReadDouble();
        SlaveTurn = reader.ReadVarUShort();
        ushort slaveSpellsCount = reader.ReadUShort();
        var slaveSpells_ = new SpellItem[slaveSpellsCount];

        for (var slaveSpellsIndex = 0; slaveSpellsIndex < slaveSpellsCount; slaveSpellsIndex++)
        {
            var objectToAdd = new SpellItem();
            objectToAdd.Deserialize(reader);
            slaveSpells_[slaveSpellsIndex] = objectToAdd;
        }
        SlaveSpells = slaveSpells_;
        SlaveStats = new CharacterCharacteristicsInformations();
        SlaveStats.Deserialize(reader);
        ushort shortcutsCount = reader.ReadUShort();
        var shortcuts_ = new Shortcut[shortcutsCount];

        for (var shortcutsIndex = 0; shortcutsIndex < shortcutsCount; shortcutsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<Shortcut>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            shortcuts_[shortcutsIndex] = objectToAdd;
        }
        Shortcuts = shortcuts_;
    }
}