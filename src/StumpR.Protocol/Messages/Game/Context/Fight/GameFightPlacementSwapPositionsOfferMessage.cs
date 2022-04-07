using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightPlacementSwapPositionsOfferMessage : Message
{
    public const uint Id = 519;

    public GameFightPlacementSwapPositionsOfferMessage(int requestId,
        double requesterId,
        ushort requesterCellId,
        double requestedId,
        ushort requestedCellId)
    {
        RequestId = requestId;
        RequesterId = requesterId;
        RequesterCellId = requesterCellId;
        RequestedId = requestedId;
        RequestedCellId = requestedCellId;
    }

    public GameFightPlacementSwapPositionsOfferMessage()
    {
    }

    public override uint MessageId => Id;

    public int RequestId { get; set; }

    public double RequesterId { get; set; }

    public ushort RequesterCellId { get; set; }

    public double RequestedId { get; set; }

    public ushort RequestedCellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(RequestId);
        writer.WriteDouble(RequesterId);
        writer.WriteVarUShort(RequesterCellId);
        writer.WriteDouble(RequestedId);
        writer.WriteVarUShort(RequestedCellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        RequestId = reader.ReadInt();
        RequesterId = reader.ReadDouble();
        RequesterCellId = reader.ReadVarUShort();
        RequestedId = reader.ReadDouble();
        RequestedCellId = reader.ReadVarUShort();
    }
}