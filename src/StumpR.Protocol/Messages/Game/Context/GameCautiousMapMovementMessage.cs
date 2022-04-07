using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameCautiousMapMovementMessage : GameMapMovementMessage
{
    public new const uint Id = 431;

    public GameCautiousMapMovementMessage(IEnumerable<short> keyMovements, short forcedDirection, double actorId)
    {
        KeyMovements = keyMovements;
        ForcedDirection = forcedDirection;
        ActorId = actorId;
    }

    public GameCautiousMapMovementMessage()
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