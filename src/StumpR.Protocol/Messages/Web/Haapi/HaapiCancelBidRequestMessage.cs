using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiCancelBidRequestMessage : Message
{
    public const uint Id = 3479;

    public HaapiCancelBidRequestMessage(ulong objectId, sbyte type)
    {
        ObjectId = objectId;
        Type = type;
    }

    public HaapiCancelBidRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ObjectId { get; set; }

    public sbyte Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectId);
        writer.WriteSByte(Type);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarULong();
        Type = reader.ReadSByte();
    }
}