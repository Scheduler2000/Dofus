using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayPrismInformations : GameRolePlayActorInformations
{
    public new const short Id = 6265;

    public GameRolePlayPrismInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        PrismInformation prism)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Prism = prism;
    }

    public GameRolePlayPrismInformations()
    {
    }

    public override short TypeId => Id;

    public PrismInformation Prism { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(Prism.TypeId);
        Prism.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
        Prism.Deserialize(reader);
    }
}