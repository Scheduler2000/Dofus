using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MoodSmileyUpdateMessage : Message
{
    public const uint Id = 8249;

    public MoodSmileyUpdateMessage(int accountId, ulong playerId, ushort smileyId)
    {
        AccountId = accountId;
        PlayerId = playerId;
        SmileyId = smileyId;
    }

    public MoodSmileyUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public int AccountId { get; set; }

    public ulong PlayerId { get; set; }

    public ushort SmileyId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(AccountId);
        writer.WriteVarULong(PlayerId);
        writer.WriteVarUShort(SmileyId);
    }

    public override void Deserialize(IDataReader reader)
    {
        AccountId = reader.ReadInt();
        PlayerId = reader.ReadVarULong();
        SmileyId = reader.ReadVarUShort();
    }
}