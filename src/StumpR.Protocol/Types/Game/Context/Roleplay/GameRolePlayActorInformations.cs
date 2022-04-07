using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayActorInformations : GameContextActorInformations
{
    public new const short Id = 102;

    public GameRolePlayActorInformations(double contextualId, EntityDispositionInformations disposition, EntityLook look)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
    }

    public GameRolePlayActorInformations()
    {
    }

    public override short TypeId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}