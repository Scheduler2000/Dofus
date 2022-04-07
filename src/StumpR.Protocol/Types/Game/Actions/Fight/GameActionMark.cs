using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameActionMark
{
    public const short Id = 158;

    public GameActionMark(double markAuthorId,
        sbyte markTeamId,
        int markSpellId,
        short markSpellLevel,
        short markId,
        sbyte markType,
        short markimpactCell,
        IEnumerable<GameActionMarkedCell> cells,
        bool active)
    {
        MarkAuthorId = markAuthorId;
        MarkTeamId = markTeamId;
        MarkSpellId = markSpellId;
        MarkSpellLevel = markSpellLevel;
        MarkId = markId;
        MarkType = markType;
        MarkimpactCell = markimpactCell;
        Cells = cells;
        Active = active;
    }

    public GameActionMark()
    {
    }

    public virtual short TypeId => Id;

    public double MarkAuthorId { get; set; }

    public sbyte MarkTeamId { get; set; }

    public int MarkSpellId { get; set; }

    public short MarkSpellLevel { get; set; }

    public short MarkId { get; set; }

    public sbyte MarkType { get; set; }

    public short MarkimpactCell { get; set; }

    public IEnumerable<GameActionMarkedCell> Cells { get; set; }

    public bool Active { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MarkAuthorId);
        writer.WriteSByte(MarkTeamId);
        writer.WriteInt(MarkSpellId);
        writer.WriteShort(MarkSpellLevel);
        writer.WriteShort(MarkId);
        writer.WriteSByte(MarkType);
        writer.WriteShort(MarkimpactCell);
        writer.WriteShort((short) Cells.Count());
        foreach (GameActionMarkedCell objectToSend in Cells) objectToSend.Serialize(writer);
        writer.WriteBoolean(Active);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        MarkAuthorId = reader.ReadDouble();
        MarkTeamId = reader.ReadSByte();
        MarkSpellId = reader.ReadInt();
        MarkSpellLevel = reader.ReadShort();
        MarkId = reader.ReadShort();
        MarkType = reader.ReadSByte();
        MarkimpactCell = reader.ReadShort();
        ushort cellsCount = reader.ReadUShort();
        var cells_ = new GameActionMarkedCell[cellsCount];

        for (var cellsIndex = 0; cellsIndex < cellsCount; cellsIndex++)
        {
            var objectToAdd = new GameActionMarkedCell();
            objectToAdd.Deserialize(reader);
            cells_[cellsIndex] = objectToAdd;
        }
        Cells = cells_;
        Active = reader.ReadBoolean();
    }
}