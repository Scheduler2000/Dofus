using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TreasureHuntStepFollowDirection : TreasureHuntStep
{
    public new const short Id = 5753;

    public TreasureHuntStepFollowDirection(sbyte direction, ushort mapCount)
    {
        Direction = direction;
        MapCount = mapCount;
    }

    public TreasureHuntStepFollowDirection()
    {
    }

    public override short TypeId => Id;

    public sbyte Direction { get; set; }

    public ushort MapCount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(Direction);
        writer.WriteVarUShort(MapCount);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Direction = reader.ReadSByte();
        MapCount = reader.ReadVarUShort();
    }
}