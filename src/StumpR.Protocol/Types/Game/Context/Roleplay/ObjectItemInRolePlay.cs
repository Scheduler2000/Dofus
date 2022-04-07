using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectItemInRolePlay
{
    public const short Id = 4848;

    public ObjectItemInRolePlay(ushort cellId, ushort objectGID)
    {
        CellId = cellId;
        ObjectGID = objectGID;
    }

    public ObjectItemInRolePlay()
    {
    }

    public virtual short TypeId => Id;

    public ushort CellId { get; set; }

    public ushort ObjectGID { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CellId);
        writer.WriteVarUShort(ObjectGID);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadVarUShort();
        ObjectGID = reader.ReadVarUShort();
    }
}