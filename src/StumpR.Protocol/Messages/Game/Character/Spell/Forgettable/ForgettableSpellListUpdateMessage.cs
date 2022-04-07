using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ForgettableSpellListUpdateMessage : Message
{
    public const uint Id = 9946;

    public ForgettableSpellListUpdateMessage(sbyte action, IEnumerable<ForgettableSpellItem> spells)
    {
        Action = action;
        Spells = spells;
    }

    public ForgettableSpellListUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Action { get; set; }

    public IEnumerable<ForgettableSpellItem> Spells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Action);
        writer.WriteShort((short) Spells.Count());
        foreach (ForgettableSpellItem objectToSend in Spells) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Action = reader.ReadSByte();
        ushort spellsCount = reader.ReadUShort();
        var spells_ = new ForgettableSpellItem[spellsCount];

        for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++)
        {
            var objectToAdd = new ForgettableSpellItem();
            objectToAdd.Deserialize(reader);
            spells_[spellsIndex] = objectToAdd;
        }
        Spells = spells_;
    }
}