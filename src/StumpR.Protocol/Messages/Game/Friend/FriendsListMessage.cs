using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendsListMessage : Message
{
    public const uint Id = 6666;

    public FriendsListMessage(IEnumerable<FriendInformations> friendsList)
    {
        FriendsList = friendsList;
    }

    public FriendsListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<FriendInformations> FriendsList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) FriendsList.Count());

        foreach (FriendInformations objectToSend in FriendsList)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort friendsListCount = reader.ReadUShort();
        var friendsList_ = new FriendInformations[friendsListCount];

        for (var friendsListIndex = 0; friendsListIndex < friendsListCount; friendsListIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            friendsList_[friendsListIndex] = objectToAdd;
        }
        FriendsList = friendsList_;
    }
}