using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightLoot
{
    public const short Id = 7224;

    public FightLoot(IEnumerable<uint> objects, ulong kamas)
    {
        Objects = objects;
        Kamas = kamas;
    }

    public FightLoot()
    {
    }

    public virtual short TypeId => Id;

    public IEnumerable<uint> Objects { get; set; }

    public ulong Kamas { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Objects.Count());
        foreach (uint objectToSend in Objects) writer.WriteVarUInt(objectToSend);
        writer.WriteVarULong(Kamas);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ushort objectsCount = reader.ReadUShort();
        var objects_ = new uint[objectsCount];
        for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++) objects_[objectsIndex] = reader.ReadVarUInt();
        Objects = objects_;
        Kamas = reader.ReadVarULong();
    }
}