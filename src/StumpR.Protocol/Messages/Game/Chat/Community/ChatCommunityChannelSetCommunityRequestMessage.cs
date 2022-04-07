using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatCommunityChannelSetCommunityRequestMessage : Message
{
    public const uint Id = 9201;

    public ChatCommunityChannelSetCommunityRequestMessage(short communityId)
    {
        CommunityId = communityId;
    }

    public ChatCommunityChannelSetCommunityRequestMessage()
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