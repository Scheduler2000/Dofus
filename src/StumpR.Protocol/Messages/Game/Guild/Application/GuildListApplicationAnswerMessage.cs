using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildListApplicationAnswerMessage : PaginationAnswerAbstractMessage
{
    public new const uint Id = 1223;

    public GuildListApplicationAnswerMessage(double offset, uint count, uint total, IEnumerable<GuildApplicationInformation> applies)
    {
        Offset = offset;
        Count = count;
        Total = total;
        Applies = applies;
    }

    public GuildListApplicationAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GuildApplicationInformation> Applies { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Applies.Count());
        foreach (GuildApplicationInformation objectToSend in Applies) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort appliesCount = reader.ReadUShort();
        var applies_ = new GuildApplicationInformation[appliesCount];

        for (var appliesIndex = 0; appliesIndex < appliesCount; appliesIndex++)
        {
            var objectToAdd = new GuildApplicationInformation();
            objectToAdd.Deserialize(reader);
            applies_[appliesIndex] = objectToAdd;
        }
        Applies = applies_;
    }
}