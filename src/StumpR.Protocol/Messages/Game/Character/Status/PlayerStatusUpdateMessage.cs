using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PlayerStatusUpdateMessage : Message
{
    public const uint Id = 120;

    public PlayerStatusUpdateMessage(int accountId, ulong playerId, PlayerStatus status)
    {
        AccountId = accountId;
        PlayerId = playerId;
        Status = status;
    }

    public PlayerStatusUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public int AccountId { get; set; }

    public ulong PlayerId { get; set; }

    public PlayerStatus Status { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(AccountId);
        writer.WriteVarULong(PlayerId);
        writer.WriteShort(Status.TypeId);
        Status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        AccountId = reader.ReadInt();
        PlayerId = reader.ReadVarULong();
        Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
        Status.Deserialize(reader);
    }
}