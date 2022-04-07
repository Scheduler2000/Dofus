using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightPlacementSwapPositionsAcceptMessage : Message
{
    public const uint Id = 2140;

    public GameFightPlacementSwapPositionsAcceptMessage(int requestId)
    {
        RequestId = requestId;
    }

    public GameFightPlacementSwapPositionsAcceptMessage()
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