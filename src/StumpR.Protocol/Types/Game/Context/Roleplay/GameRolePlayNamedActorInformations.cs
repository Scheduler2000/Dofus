using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
{
    public new const short Id = 6660;

    public GameRolePlayNamedActorInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        string name)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Name = name;
    }

    public GameRolePlayNamedActorInformations()
    {
    }

    public override short TypeId => Id;

    public string Name { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
    }
}