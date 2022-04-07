using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameContextActorInformations : GameContextActorPositionInformations
{
    public new const short Id = 801;

    public GameContextActorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
    }

    public GameContextActorInformations()
    {
    }

    public override short TypeId => Id;

    public EntityLook Look { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}