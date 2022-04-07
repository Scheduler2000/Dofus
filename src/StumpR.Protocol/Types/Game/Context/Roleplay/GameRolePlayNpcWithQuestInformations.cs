using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayNpcWithQuestInformations : GameRolePlayNpcInformations
{
    public new const short Id = 3824;

    public GameRolePlayNpcWithQuestInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        ushort npcId,
        bool sex,
        ushort specialArtworkId,
        GameRolePlayNpcQuestFlag questFlag)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        NpcId = npcId;
        Sex = sex;
        SpecialArtworkId = specialArtworkId;
        QuestFlag = questFlag;
    }

    public GameRolePlayNpcWithQuestInformations()
    {
    }

    public override short TypeId => Id;

    public GameRolePlayNpcQuestFlag QuestFlag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        QuestFlag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        QuestFlag = new GameRolePlayNpcQuestFlag();
        QuestFlag.Deserialize(reader);
    }
}