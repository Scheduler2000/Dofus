using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagPackListMessage : Message
{
    public const uint Id = 268;

    public HavenBagPackListMessage(IEnumerable<sbyte> packIds)
    {
        PackIds = packIds;
    }

    public HavenBagPackListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<sbyte> PackIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) PackIds.Count());
        foreach (sbyte objectToSend in PackIds) writer.WriteSByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort packIdsCount = reader.ReadUShort();
        var packIds_ = new sbyte[packIdsCount];
        for (var packIdsIndex = 0; packIdsIndex < packIdsCount; packIdsIndex++) packIds_[packIdsIndex] = reader.ReadSByte();
        PackIds = packIds_;
    }
}