using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountSterilizedMessage : Message
{
    public const uint Id = 3777;

    public MountSterilizedMessage(int mountId)
    {
        MountId = mountId;
    }

    public MountSterilizedMessage()
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