using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightPlacementSwapPositionsCancelMessage : Message
{
    public const uint Id = 7054;

    public GameFightPlacementSwapPositionsCancelMessage(int requestId)
    {
        RequestId = requestId;
    }

    public GameFightPlacementSwapPositionsCancelMessage()
    {
    }

    public override uint MessageId => Id;

    public int RequestId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(RequestId);
    }

    public override void Deserialize(IDataReader reader)
    {
        RequestId = reader.ReadInt();
    }
}