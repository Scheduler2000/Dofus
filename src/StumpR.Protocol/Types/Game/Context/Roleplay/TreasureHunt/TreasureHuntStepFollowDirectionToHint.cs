using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TreasureHuntStepFollowDirectionToHint : TreasureHuntStep
{
    public new const short Id = 4752;

    public TreasureHuntStepFollowDirectionToHint(sbyte direction, ushort npcId)
    {
        Direction = direction;
        NpcId = npcId;
    }

    public TreasureHuntStepFollowDirectionToHint()
    {
    }

    public override short TypeId => Id;

    public sbyte Direction { get; set; }

    public ushort NpcId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(Direction);
        writer.WriteVarUShort(NpcId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Direction = reader.ReadSByte();
        NpcId = reader.ReadVarUShort();
    }
}