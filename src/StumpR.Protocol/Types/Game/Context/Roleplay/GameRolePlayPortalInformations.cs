using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayPortalInformations : GameRolePlayActorInformations
{
    public new const short Id = 8125;

    public GameRolePlayPortalInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        PortalInformation portal)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Portal = portal;
    }

    public GameRolePlayPortalInformations()
    {
    }

    public override short TypeId => Id;

    public PortalInformation Portal { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(Portal.TypeId);
        Portal.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Portal = ProtocolTypeManager.GetInstance<PortalInformation>(reader.ReadShort());
        Portal.Deserialize(reader);
    }
}