using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightEntityDispositionInformations : EntityDispositionInformations
{
    public new const short Id = 7794;

    public FightEntityDispositionInformations(short cellId, sbyte direction, double carryingCharacterId)
    {
        CellId = cellId;
        Direction = direction;
        CarryingCharacterId = carryingCharacterId;
    }

    public FightEntityDispositionInformations()
    {
    }

    public override short TypeId => Id;

    public double CarryingCharacterId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(CarryingCharacterId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CarryingCharacterId = reader.ReadDouble();
    }
}