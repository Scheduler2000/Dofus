using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextMoveMultipleElementsMessage : Message
{
    public const uint Id = 2401;

    public GameContextMoveMultipleElementsMessage(IEnumerable<EntityMovementInformations> movements)
    {
        Movements = movements;
    }

    public GameContextMoveMultipleElementsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<EntityMovementInformations> Movements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Movements.Count());
        foreach (EntityMovementInformations objectToSend in Movements) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort movementsCount = reader.ReadUShort();
        var movements_ = new EntityMovementInformations[movementsCount];

        for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
        {
            var objectToAdd = new EntityMovementInformations();
            objectToAdd.Deserialize(reader);
            movements_[movementsIndex] = objectToAdd;
        }
        Movements = movements_;
    }
}