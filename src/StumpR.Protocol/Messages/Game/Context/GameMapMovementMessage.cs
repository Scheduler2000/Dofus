using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameMapMovementMessage : Message
{
    public const uint Id = 1972;

    public GameMapMovementMessage(IEnumerable<short> keyMovements, short forcedDirection, double actorId)
    {
        KeyMovements = keyMovements;
        ForcedDirection = forcedDirection;
        ActorId = actorId;
    }

    public GameMapMovementMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<short> KeyMovements { get; set; }

    public short ForcedDirection { get; set; }

    public double ActorId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) KeyMovements.Count());
        foreach (short objectToSend in KeyMovements) writer.WriteShort(objectToSend);
        writer.WriteShort(ForcedDirection);
        writer.WriteDouble(ActorId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort keyMovementsCount = reader.ReadUShort();
        var keyMovements_ = new short[keyMovementsCount];

        for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
            keyMovements_[keyMovementsIndex] = reader.ReadShort();
        KeyMovements = keyMovements_;
        ForcedDirection = reader.ReadShort();
        ActorId = reader.ReadDouble();
    }
}