using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
{
    public new const short Id = 3148;

    public GameRolePlayGroupMonsterInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        bool keyRingBonus,
        bool hasHardcoreDrop,
        bool hasAVARewardToken,
        GroupMonsterStaticInformations staticInfos,
        sbyte lootShare,
        sbyte alignmentSide)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        KeyRingBonus = keyRingBonus;
        HasHardcoreDrop = hasHardcoreDrop;
        HasAVARewardToken = hasAVARewardToken;
        StaticInfos = staticInfos;
        LootShare = lootShare;
        AlignmentSide = alignmentSide;
    }

    public GameRolePlayGroupMonsterInformations()
    {
    }

    public override short TypeId => Id;

    public bool KeyRingBonus { get; set; }

    public bool HasHardcoreDrop { get; set; }

    public bool HasAVARewardToken { get; set; }

    public GroupMonsterStaticInformations StaticInfos { get; set; }

    public sbyte LootShare { get; set; }

    public sbyte AlignmentSide { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, KeyRingBonus);
        flag = BooleanByteWrapper.SetFlag(flag, 1, HasHardcoreDrop);
        flag = BooleanByteWrapper.SetFlag(flag, 2, HasAVARewardToken);
        writer.WriteByte(flag);
        writer.WriteShort(StaticInfos.TypeId);
        StaticInfos.Serialize(writer);
        writer.WriteSByte(LootShare);
        writer.WriteSByte(AlignmentSide);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        byte flag = reader.ReadByte();
        KeyRingBonus = BooleanByteWrapper.GetFlag(flag, 0);
        HasHardcoreDrop = BooleanByteWrapper.GetFlag(flag, 1);
        HasAVARewardToken = BooleanByteWrapper.GetFlag(flag, 2);
        StaticInfos = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
        StaticInfos.Deserialize(reader);
        LootShare = reader.ReadSByte();
        AlignmentSide = reader.ReadSByte();
    }
}