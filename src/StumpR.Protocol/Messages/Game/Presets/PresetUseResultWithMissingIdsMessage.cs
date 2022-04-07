using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage
{
    public new const uint Id = 2217;

    public PresetUseResultWithMissingIdsMessage(short presetId, sbyte code, IEnumerable<ushort> missingIds)
    {
        PresetId = presetId;
        Code = code;
        MissingIds = missingIds;
    }

    public PresetUseResultWithMissingIdsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> MissingIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) MissingIds.Count());
        foreach (ushort objectToSend in MissingIds) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort missingIdsCount = reader.ReadUShort();
        var missingIds_ = new ushort[missingIdsCount];

        for (var missingIdsIndex = 0; missingIdsIndex < missingIdsCount; missingIdsIndex++)
            missingIds_[missingIdsIndex] = reader.ReadVarUShort();
        MissingIds = missingIds_;
    }
}