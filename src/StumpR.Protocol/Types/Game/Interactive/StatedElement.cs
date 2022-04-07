using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class StatedElement
{
    public const short Id = 7058;

    public StatedElement(int elementId, ushort elementCellId, uint elementState, bool onCurrentMap)
    {
        ElementId = elementId;
        ElementCellId = elementCellId;
        ElementState = elementState;
        OnCurrentMap = onCurrentMap;
    }

    public StatedElement()
    {
    }

    public virtual short TypeId => Id;

    public int ElementId { get; set; }

    public ushort ElementCellId { get; set; }

    public uint ElementState { get; set; }

    public bool OnCurrentMap { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ElementId);
        writer.WriteVarUShort(ElementCellId);
        writer.WriteVarUInt(ElementState);
        writer.WriteBoolean(OnCurrentMap);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ElementId = reader.ReadInt();
        ElementCellId = reader.ReadVarUShort();
        ElementState = reader.ReadVarUInt();
        OnCurrentMap = reader.ReadBoolean();
    }
}