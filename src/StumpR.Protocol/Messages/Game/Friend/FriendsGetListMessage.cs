using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FriendsGetListMessage : Message
{
    public const uint Id = 3044;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}