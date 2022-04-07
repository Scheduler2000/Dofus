using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayGroupMonsterWaveInformations : GameRolePlayGroupMonsterInformations
{
    public new const short Id = 5382;

    public GameRolePlayGroupMonsterWaveInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        bool keyRingBonus,
        bool hasHardcoreDrop,
        bool hasAVARewardToken,
        GroupMonsterStaticInformations staticInfos,
        sbyte lootShare,
        sbyte alignmentSide,
        sbyte nbWaves,
        IEnumerable<GroupMonsterStaticInformations> alternatives)
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
        NbWaves = nbWaves;
        Alternatives = alternatives;
    }

    public GameRolePlayGroupMonsterWaveInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte NbWaves { get; set; }

    public IEnumerable<GroupMonsterStaticInformations> Alternatives { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(NbWaves);
        writer.WriteShort((short) Alternatives.Count());

        foreach (GroupMonsterStaticInformations objectToSend in Alternatives)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        NbWaves = reader.ReadSByte();
        ushort alternativesCount = reader.ReadUShort();
        var alternatives_ = new GroupMonsterStaticInformations[alternativesCount];

        for (var alternativesIndex = 0; alternativesIndex < alternativesCount; alternativesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            alternatives_[alternativesIndex] = objectToAdd;
        }
        Alternatives = alternatives_;
    }
}