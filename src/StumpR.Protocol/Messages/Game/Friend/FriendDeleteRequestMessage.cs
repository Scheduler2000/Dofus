using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendDeleteRequestMessage : Message
{
    public const uint Id = 7400;

    public FriendDeleteRequestMessage(int accountId)
    {
        AccountId = accountId;
    }

    public FriendDeleteRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int AccountId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(AccountId);
    }

    public override void Deserialize(IDataReader reader)
    {
        AccountId = reader.ReadInt();
    }
}