using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class EntitiesPreset : Preset
{
    public new const short Id = 1197;

    public EntitiesPreset(short objectId, short iconId, IEnumerable<ushort> entityIds)
    {
        ObjectId = objectId;
        IconId = iconId;
        EntityIds = entityIds;
    }

    public EntitiesPreset()
    {
    }

    public override short TypeId => Id;

    public short IconId { get; set; }

    public IEnumerable<ushort> EntityIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(IconId);
        writer.WriteShort((short) EntityIds.Count());
        foreach (ushort objectToSend in EntityIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        IconId = reader.ReadShort();
        ushort entityIdsCount = reader.ReadUShort();
        var entityIds_ = new ushort[entityIdsCount];

        for (var entityIdsIndex = 0; entityIdsIndex < entityIdsCount; entityIdsIndex++)
            entityIds_[entityIdsIndex] = reader.ReadVarUShort();
        EntityIds = entityIds_;
    }
}