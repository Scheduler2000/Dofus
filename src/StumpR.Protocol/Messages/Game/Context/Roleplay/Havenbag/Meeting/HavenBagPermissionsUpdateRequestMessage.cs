using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HavenBagPermissionsUpdateRequestMessage : Message
{
    public const uint Id = 2106;

    public HavenBagPermissionsUpdateRequestMessage(int permissions)
    {
        Permissions = permissions;
    }

    public HavenBagPermissionsUpdateRequestMessage()
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