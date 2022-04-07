using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatCommunityChannelCommunityMessage : Message
{
    public const uint Id = 9671;

    public ChatCommunityChannelCommunityMessage(short communityId)
    {
        CommunityId = communityId;
    }

    public ChatCommunityChannelCommunityMessage()
    {
    }

    public override uint MessageId => Id;

    public short CommunityId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(CommunityId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CommunityId = reader.ReadShort();
    }
}