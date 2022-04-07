using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildSummaryMessage : PaginationAnswerAbstractMessage
{
    public new const uint Id = 4399;

    public GuildSummaryMessage(double offset, uint count, uint total, IEnumerable<GuildFactSheetInformations> guilds)
    {
        Offset = offset;
        Count = count;
        Total = total;
        Guilds = guilds;
    }

    public GuildSummaryMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GuildFactSheetInformations> Guilds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Guilds.Count());
        foreach (GuildFactSheetInformations objectToSend in Guilds) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort guildsCount = reader.ReadUShort();
        var guilds_ = new GuildFactSheetInformations[guildsCount];

        for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
        {
            var objectToAdd = new GuildFactSheetInformations();
            objectToAdd.Deserialize(reader);
            guilds_[guildsIndex] = objectToAdd;
        }
        Guilds = guilds_;
    }
}