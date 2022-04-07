using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionOrnament : HumanOption
{
    public new const short Id = 5510;

    public HumanOptionOrnament(ushort ornamentId, ushort level, short leagueId, int ladderPosition)
    {
        OrnamentId = ornamentId;
        Level = level;
        LeagueId = leagueId;
        LadderPosition = ladderPosition;
    }

    public HumanOptionOrnament()
    {
    }

    public override short TypeId => Id;

    public ushort OrnamentId { get; set; }

    public ushort Level { get; set; }

    public short LeagueId { get; set; }

    public int LadderPosition { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(OrnamentId);
        writer.WriteVarUShort(Level);
        writer.WriteVarShort(LeagueId);
        writer.WriteInt(LadderPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        OrnamentId = reader.ReadVarUShort();
        Level = reader.ReadVarUShort();
        LeagueId = reader.ReadVarShort();
        LadderPosition = reader.ReadInt();
    }
}