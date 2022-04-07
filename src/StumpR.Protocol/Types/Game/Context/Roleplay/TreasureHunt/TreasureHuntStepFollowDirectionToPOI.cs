using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
{
    public new const short Id = 2093;

    public TreasureHuntStepFollowDirectionToPOI(sbyte direction, ushort poiLabelId)
    {
        Direction = direction;
        PoiLabelId = poiLabelId;
    }

    public TreasureHuntStepFollowDirectionToPOI()
    {
    }

    public override short TypeId => Id;

    public sbyte Direction { get; set; }

    public ushort PoiLabelId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(Direction);
        writer.WriteVarUShort(PoiLabelId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Direction = reader.ReadSByte();
        PoiLabelId = reader.ReadVarUShort();
    }
}