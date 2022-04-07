using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
{
    public new const short Id = 9304;

    public GameRolePlayMountInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        string name,
        string ownerName,
        byte level)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Name = name;
        OwnerName = ownerName;
        Level = level;
    }

    public GameRolePlayMountInformations()
    {
    }

    public override short TypeId => Id;

    public string OwnerName { get; set; }

    public byte Level { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(OwnerName);
        writer.WriteByte(Level);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        OwnerName = reader.ReadUTF();
        Level = reader.ReadByte();
    }
}