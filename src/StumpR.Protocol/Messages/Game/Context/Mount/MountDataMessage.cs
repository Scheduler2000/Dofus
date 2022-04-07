using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountDataMessage : Message
{
    public const uint Id = 5244;

    public MountDataMessage(MountClientData mountData)
    {
        MountData = mountData;
    }

    public MountDataMessage()
    {
    }

    public override uint MessageId => Id;

    public MountClientData MountData { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        MountData.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        MountData = new MountClientData();
        MountData.Deserialize(reader);
    }
}