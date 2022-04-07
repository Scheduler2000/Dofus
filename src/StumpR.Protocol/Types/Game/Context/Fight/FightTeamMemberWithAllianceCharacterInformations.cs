using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTeamMemberWithAllianceCharacterInformations : FightTeamMemberCharacterInformations
{
    public new const short Id = 2689;

    public FightTeamMemberWithAllianceCharacterInformations(double objectId,
        string name,
        ushort level,
        BasicAllianceInformations allianceInfos)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        AllianceInfos = allianceInfos;
    }

    public FightTeamMemberWithAllianceCharacterInformations()
    {
    }

    public override short TypeId => Id;

    public BasicAllianceInformations AllianceInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AllianceInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceInfos = new BasicAllianceInformations();
        AllianceInfos.Deserialize(reader);
    }
}