using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatSmileyExtraPackListMessage : Message
{
    public const uint Id = 8664;

    public ChatSmileyExtraPackListMessage(IEnumerable<byte> packIds)
    {
        PackIds = packIds;
    }

    public ChatSmileyExtraPackListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<byte> PackIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PackIds.Count());
        foreach (byte objectToSend in PackIds) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort packIdsCount = reader.ReadUShort();
        var packIds_ = new byte[packIdsCount];
        for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++) packIds_[packIdsIndex] = reader.ReadByte();
        PackIds = packIds_;
    }
}