using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTeamMemberMonsterInformations : FightTeamMemberInformations
{
    public new const short Id = 6386;

    public FightTeamMemberMonsterInformations(double objectId, int monsterId, sbyte grade)
    {
        ObjectId = objectId;
        MonsterId = monsterId;
        Grade = grade;
    }

    public FightTeamMemberMonsterInformations()
    {
    }

    public override short TypeId => Id;

    public int MonsterId { get; set; }

    public sbyte Grade { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(MonsterId);
        writer.WriteSByte(Grade);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MonsterId = reader.ReadInt();
        Grade = reader.ReadSByte();
    }
}