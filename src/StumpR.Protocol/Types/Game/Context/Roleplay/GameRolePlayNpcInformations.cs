using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayNpcInformations : GameRolePlayActorInformations
{
    public new const short Id = 7419;

    public GameRolePlayNpcInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        ushort npcId,
        bool sex,
        ushort specialArtworkId)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        NpcId = npcId;
        Sex = sex;
        SpecialArtworkId = specialArtworkId;
    }

    public GameRolePlayNpcInformations()
    {
    }

    public override short TypeId => Id;

    public ushort NpcId { get; set; }

    public bool Sex { get; set; }

    public ushort SpecialArtworkId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(NpcId);
        writer.WriteBoolean(Sex);
        writer.WriteVarUShort(SpecialArtworkId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        NpcId = reader.ReadVarUShort();
        Sex = reader.ReadBoolean();
        SpecialArtworkId = reader.ReadVarUShort();
    }
}