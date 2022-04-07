using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ItemForPreset
{
    public const short Id = 4107;

    public ItemForPreset(short position, ushort objGid, uint objUid)
    {
        Position = position;
        ObjGid = objGid;
        ObjUid = objUid;
    }

    public ItemForPreset()
    {
    }

    public virtual short TypeId => Id;

    public short Position { get; set; }

    public ushort ObjGid { get; set; }

    public uint ObjUid { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Position);
        writer.WriteVarUShort(ObjGid);
        writer.WriteVarUInt(ObjUid);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Position = reader.ReadShort();
        ObjGid = reader.ReadVarUShort();
        ObjUid = reader.ReadVarUInt();
    }
}