using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PaddockInformationsForSell
{
    public const short Id = 1249;

    public PaddockInformationsForSell(string guildOwner,
        short worldX,
        short worldY,
        ushort subAreaId,
        sbyte nbMount,
        sbyte nbObject,
        ulong price)
    {
        GuildOwner = guildOwner;
        WorldX = worldX;
        WorldY = worldY;
        SubAreaId = subAreaId;
        NbMount = nbMount;
        NbObject = nbObject;
        Price = price;
    }

    public PaddockInformationsForSell()
    {
    }

    public virtual short TypeId => Id;

    public string GuildOwner { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public ushort SubAreaId { get; set; }

    public sbyte NbMount { get; set; }

    public sbyte NbObject { get; set; }

    public ulong Price { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(GuildOwner);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteSByte(NbMount);
        writer.WriteSByte(NbObject);
        writer.WriteVarULong(Price);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        GuildOwner = reader.ReadUTF();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        SubAreaId = reader.ReadVarUShort();
        NbMount = reader.ReadSByte();
        NbObject = reader.ReadSByte();
        Price = reader.ReadVarULong();
    }
}