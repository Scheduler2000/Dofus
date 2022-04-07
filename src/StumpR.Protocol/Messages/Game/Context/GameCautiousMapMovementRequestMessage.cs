using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameCautiousMapMovementRequestMessage : GameMapMovementRequestMessage
{
    public new const uint Id = 1760;

    public GameCautiousMapMovementRequestMessage(IEnumerable<short> keyMovements, double mapId)
    {
        KeyMovements = keyMovements;
        MapId = mapId;
    }

    public GameCautiousMapMovementRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}