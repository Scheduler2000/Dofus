using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
{
    public new const short Id = 5071;

    public GameRolePlayTaxCollectorInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        TaxCollectorStaticInformations identification,
        byte guildLevel,
        int taxCollectorAttack)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Identification = identification;
        GuildLevel = guildLevel;
        TaxCollectorAttack = taxCollectorAttack;
    }

    public GameRolePlayTaxCollectorInformations()
    {
    }

    public override short TypeId => Id;

    public TaxCollectorStaticInformations Identification { get; set; }

    public byte GuildLevel { get; set; }

    public int TaxCollectorAttack { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(Identification.TypeId);
        Identification.Serialize(writer);
        writer.WriteByte(GuildLevel);
        writer.WriteInt(TaxCollectorAttack);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Identification = ProtocolTypeManager.GetInstance<TaxCollectorStaticInformations>(reader.ReadShort());
        Identification.Deserialize(reader);
        GuildLevel = reader.ReadByte();
        TaxCollectorAttack = reader.ReadInt();
    }
}