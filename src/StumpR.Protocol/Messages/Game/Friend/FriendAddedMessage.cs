using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendAddedMessage : Message
{
    public const uint Id = 9476;

    public FriendAddedMessage(FriendInformations friendAdded)
    {
        FriendAdded = friendAdded;
    }

    public FriendAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public FriendInformations FriendAdded { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(FriendAdded.TypeId);
        FriendAdded.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FriendAdded = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
        FriendAdded.Deserialize(reader);
    }
}