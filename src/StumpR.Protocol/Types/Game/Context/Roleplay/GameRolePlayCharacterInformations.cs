using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayCharacterInformations : GameRolePlayHumanoidInformations
{
    public new const short Id = 9532;

    public GameRolePlayCharacterInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        string name,
        HumanInformations humanoidInfo,
        int accountId,
        ActorAlignmentInformations alignmentInfos)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Name = name;
        HumanoidInfo = humanoidInfo;
        AccountId = accountId;
        AlignmentInfos = alignmentInfos;
    }

    public GameRolePlayCharacterInformations()
    {
    }

    public override short TypeId => Id;

    public ActorAlignmentInformations AlignmentInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AlignmentInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AlignmentInfos = new ActorAlignmentInformations();
        AlignmentInfos.Deserialize(reader);
    }
}