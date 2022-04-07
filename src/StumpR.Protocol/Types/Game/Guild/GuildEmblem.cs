using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildEmblem
{
    public const short Id = 2994;

    public GuildEmblem(ushort symbolShape, int symbolColor, sbyte backgroundShape, int backgroundColor)
    {
        SymbolShape = symbolShape;
        SymbolColor = symbolColor;
        BackgroundShape = backgroundShape;
        BackgroundColor = backgroundColor;
    }

    public GuildEmblem()
    {
    }

    public virtual short TypeId => Id;

    public ushort SymbolShape { get; set; }

    public int SymbolColor { get; set; }

    public sbyte BackgroundShape { get; set; }

    public int BackgroundColor { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SymbolShape);
        writer.WriteInt(SymbolColor);
        writer.WriteSByte(BackgroundShape);
        writer.WriteInt(BackgroundColor);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        SymbolShape = reader.ReadVarUShort();
        SymbolColor = reader.ReadInt();
        BackgroundShape = reader.ReadSByte();
        BackgroundColor = reader.ReadInt();
    }
}