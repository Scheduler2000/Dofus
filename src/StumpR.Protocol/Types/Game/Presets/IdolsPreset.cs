using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class IdolsPreset : Preset
{
    public new const short Id = 6343;

    public IdolsPreset(short objectId, short iconId, IEnumerable<ushort> idolIds)
    {
        ObjectId = objectId;
        IconId = iconId;
        IdolIds = idolIds;
    }

    public IdolsPreset()
    {
    }

    public override short TypeId => Id;

    public short IconId { get; set; }

    public IEnumerable<ushort> IdolIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(IconId);
        writer.WriteShort((short) IdolIds.Count());
        foreach (ushort objectToSend in IdolIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        IconId = reader.ReadShort();
        ushort idolIdsCount = reader.ReadUShort();
        var idolIds_ = new ushort[idolIdsCount];
        for (var idolIdsIndex = 0; idolIdsIndex < idolIdsCount; idolIdsIndex++) idolIds_[idolIdsIndex] = reader.ReadVarUShort();
        IdolIds = idolIds_;
    }
}