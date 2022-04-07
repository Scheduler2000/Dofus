using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagPermissionsUpdateMessage : Message
{
    public const uint Id = 3186;

    public HavenBagPermissionsUpdateMessage(int permissions)
    {
        Permissions = permissions;
    }

    public HavenBagPermissionsUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public int Permissions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(Permissions);
    }

    public override void Deserialize(IDataReader reader)
    {
        Permissions = reader.ReadInt();
    }
}