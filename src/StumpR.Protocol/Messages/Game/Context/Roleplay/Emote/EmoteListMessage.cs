using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EmoteListMessage : Message
{
    public const uint Id = 9032;

    public EmoteListMessage(IEnumerable<ushort> emoteIds)
    {
        EmoteIds = emoteIds;
    }

    public EmoteListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> EmoteIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) EmoteIds.Count());
        foreach (ushort objectToSend in EmoteIds) writer.WriteUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort emoteIdsCount = reader.ReadUShort();
        var emoteIds_ = new ushort[emoteIdsCount];
        for (var emoteIdsIndex = 0; emoteIdsIndex < emoteIdsCount; emoteIdsIndex++) emoteIds_[emoteIdsIndex] = reader.ReadUShort();
        EmoteIds = emoteIds_;
    }
}