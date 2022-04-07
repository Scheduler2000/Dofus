using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class IdentifiedEntityDispositionInformations : EntityDispositionInformations
{
    public new const short Id = 8490;

    public IdentifiedEntityDispositionInformations(short cellId, sbyte direction, double objectId)
    {
        CellId = cellId;
        Direction = direction;
        ObjectId = objectId;
    }

    public IdentifiedEntityDispositionInformations()
    {
    }

    public override short TypeId => Id;

    public double ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectId = reader.ReadDouble();
    }
}