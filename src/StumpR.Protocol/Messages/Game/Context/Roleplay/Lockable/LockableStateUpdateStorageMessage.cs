using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
{
    public new const uint Id = 5127;

    public LockableStateUpdateStorageMessage(bool locked, double mapId, uint elementId)
    {
        Locked = locked;
        MapId = mapId;
        ElementId = elementId;
    }

    public LockableStateUpdateStorageMessage()
    {
    }

    public override uint MessageId => Id;

    public double MapId { get; set; }

    public uint ElementId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(MapId);
        writer.WriteVarUInt(ElementId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MapId = reader.ReadDouble();
        ElementId = reader.ReadVarUInt();
    }
}