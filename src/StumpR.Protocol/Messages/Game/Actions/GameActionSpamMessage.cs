using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionSpamMessage : Message
{
    public const uint Id = 6276;

    public GameActionSpamMessage(IEnumerable<short> cells)
    {
        Cells = cells;
    }

    public GameActionSpamMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<short> Cells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Cells.Count());
        foreach (short objectToSend in Cells) writer.WriteShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort cellsCount = reader.ReadUShort();
        var cells_ = new short[cellsCount];
        for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++) cells_[cellsIndex] = reader.ReadShort();
        Cells = cells_;
    }
}