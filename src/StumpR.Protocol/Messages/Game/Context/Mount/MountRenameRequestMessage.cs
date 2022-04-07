using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountRenameRequestMessage : Message
{
    public const uint Id = 8042;

    public MountRenameRequestMessage(string name, int mountId)
    {
        Name = name;
        MountId = mountId;
    }

    public MountRenameRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public string Name { get; set; }

    public int MountId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Name);
        writer.WriteVarInt(MountId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Name = reader.ReadUTF();
        MountId = reader.ReadVarInt();
    }
}