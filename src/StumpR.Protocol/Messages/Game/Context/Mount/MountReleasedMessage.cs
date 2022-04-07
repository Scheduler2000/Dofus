using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountReleasedMessage : Message
{
    public const uint Id = 843;

    public MountReleasedMessage(int mountId)
    {
        MountId = mountId;
    }

    public MountReleasedMessage()
    {
    }

    public override uint MessageId => Id;

    public int MountId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarInt(MountId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MountId = reader.ReadVarInt();
    }
}