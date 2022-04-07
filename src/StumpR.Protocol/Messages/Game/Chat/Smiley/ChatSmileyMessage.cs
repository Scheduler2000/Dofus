using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatSmileyMessage : Message
{
    public const uint Id = 5518;

    public ChatSmileyMessage(double entityId, ushort smileyId, int accountId)
    {
        EntityId = entityId;
        SmileyId = smileyId;
        AccountId = accountId;
    }

    public ChatSmileyMessage()
    {
    }

    public override uint MessageId => Id;

    public double EntityId { get; set; }

    public ushort SmileyId { get; set; }

    public int AccountId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(EntityId);
        writer.WriteVarUShort(SmileyId);
        writer.WriteInt(AccountId);
    }

    public override void Deserialize(IDataReader reader)
    {
        EntityId = reader.ReadDouble();
        SmileyId = reader.ReadVarUShort();
        AccountId = reader.ReadInt();
    }
}