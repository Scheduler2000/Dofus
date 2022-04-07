using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightPlacementPositionRequestMessage : Message
{
    public const uint Id = 5499;

    public GameFightPlacementPositionRequestMessage(ushort cellId)
    {
        CellId = cellId;
    }

    public GameFightPlacementPositionRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadVarUShort();
    }
}