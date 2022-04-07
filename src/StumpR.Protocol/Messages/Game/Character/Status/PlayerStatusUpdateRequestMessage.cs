using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PlayerStatusUpdateRequestMessage : Message
{
    public const uint Id = 1504;

    public PlayerStatusUpdateRequestMessage(PlayerStatus status)
    {
        Status = status;
    }

    public PlayerStatusUpdateRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public PlayerStatus Status { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Status.TypeId);
        Status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
        Status.Deserialize(reader);
    }
}