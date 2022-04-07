using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismInfoJoinLeaveRequestMessage : Message
{
    public const uint Id = 6247;

    public PrismInfoJoinLeaveRequestMessage(bool join)
    {
        Join = join;
    }

    public PrismInfoJoinLeaveRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Join { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Join);
    }

    public override void Deserialize(IDataReader reader)
    {
        Join = reader.ReadBoolean();
    }
}