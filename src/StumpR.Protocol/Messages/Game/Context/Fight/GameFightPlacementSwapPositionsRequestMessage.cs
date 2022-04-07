using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightPlacementSwapPositionsRequestMessage : GameFightPlacementPositionRequestMessage
{
    public new const uint Id = 7699;

    public GameFightPlacementSwapPositionsRequestMessage(ushort cellId, double requestedId)
    {
        CellId = cellId;
        RequestedId = requestedId;
    }

    public GameFightPlacementSwapPositionsRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public double RequestedId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(RequestedId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        RequestedId = reader.ReadDouble();
    }
}