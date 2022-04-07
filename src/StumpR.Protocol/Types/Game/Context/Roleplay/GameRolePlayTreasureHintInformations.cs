using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
{
    public new const short Id = 8741;

    public GameRolePlayTreasureHintInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        ushort npcId)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        NpcId = npcId;
    }

    public GameRolePlayTreasureHintInformations()
    {
    }

    public override short TypeId => Id;

    public ushort NpcId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(NpcId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        NpcId = reader.ReadVarUShort();
    }
}