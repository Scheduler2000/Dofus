using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ForgettableSpellDeleteMessage : Message
{
    public const uint Id = 9143;

    public ForgettableSpellDeleteMessage(sbyte reason, IEnumerable<int> spells)
    {
        Reason = reason;
        Spells = spells;
    }

    public ForgettableSpellDeleteMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public IEnumerable<int> Spells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
        writer.WriteShort((short) Spells.Count());
        foreach (int objectToSend in Spells) writer.WriteInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
        ushort spellsCount = reader.ReadUShort();
        var spells_ = new int[spellsCount];
        for (var spellsIndex = 0; spellsIndex < spellsCount; spellsIndex++) spells_[spellsIndex] = reader.ReadInt();
        Spells = spells_;
    }
}