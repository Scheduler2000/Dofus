using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildListApplicationRequestMessage : PaginationRequestAbstractMessage
{
    public new const uint Id = 2316;

    public GuildListApplicationRequestMessage(double offset, uint count)
    {
        Offset = offset;
        Count = count;
    }

    public GuildListApplicationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}