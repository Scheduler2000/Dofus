using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameMapMovementRequestMessage : Message
{
    public const uint Id = 685;

    public GameMapMovementRequestMessage(IEnumerable<short> keyMovements, double mapId)
    {
        KeyMovements = keyMovements;
        MapId = mapId;
    }

    public GameMapMovementRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<short> KeyMovements { get; set; }

    public double MapId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) KeyMovements.Count());
        foreach (short objectToSend in KeyMovements) writer.WriteShort(objectToSend);
        writer.WriteDouble(MapId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort keyMovementsCount = reader.ReadUShort();
        var keyMovements_ = new short[keyMovementsCount];

        for (var keyMovementsIndex = 0; keyMovementsIndex < keyMovementsCount; keyMovementsIndex++)
            keyMovements_[keyMovementsIndex] = reader.ReadShort();
        KeyMovements = keyMovements_;
        MapId = reader.ReadDouble();
    }
}