using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendUpdateMessage : Message
{
    public const uint Id = 2011;

    public FriendUpdateMessage(FriendInformations friendUpdated)
    {
        FriendUpdated = friendUpdated;
    }

    public FriendUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public FriendInformations FriendUpdated { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(FriendUpdated.TypeId);
        FriendUpdated.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FriendUpdated = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadShort());
        FriendUpdated.Deserialize(reader);
    }
}