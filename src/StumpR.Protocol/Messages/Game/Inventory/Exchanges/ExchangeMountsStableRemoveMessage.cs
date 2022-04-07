using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeMountsStableRemoveMessage : Message
{
    public const uint Id = 9668;

    public ExchangeMountsStableRemoveMessage(IEnumerable<int> mountsId)
    {
        MountsId = mountsId;
    }

    public ExchangeMountsStableRemoveMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<int> MountsId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) MountsId.Count());
        foreach (int objectToSend in MountsId) writer.WriteVarInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort mountsIdCount = reader.ReadUShort();
        var mountsId_ = new int[mountsIdCount];
        for (var mountsIdIndex = 0; mountsIdIndex < mountsIdCount; mountsIdIndex++) mountsId_[mountsIdIndex] = reader.ReadVarInt();
        MountsId = mountsId_;
    }
}