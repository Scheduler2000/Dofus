using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorMovementsOfflineMessage : Message
{
    public const uint Id = 3016;

    public TaxCollectorMovementsOfflineMessage(IEnumerable<TaxCollectorMovement> movements)
    {
        Movements = movements;
    }

    public TaxCollectorMovementsOfflineMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<TaxCollectorMovement> Movements { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Movements.Count());
        foreach (TaxCollectorMovement objectToSend in Movements) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort movementsCount = reader.ReadUShort();
        var movements_ = new TaxCollectorMovement[movementsCount];

        for (var movementsIndex = 0; movementsIndex < movementsCount; movementsIndex++)
        {
            var objectToAdd = new TaxCollectorMovement();
            objectToAdd.Deserialize(reader);
            movements_[movementsIndex] = objectToAdd;
        }
        Movements = movements_;
    }
}