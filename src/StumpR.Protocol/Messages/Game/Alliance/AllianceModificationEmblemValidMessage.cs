using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceModificationEmblemValidMessage : Message
{
    public const uint Id = 8937;

    public AllianceModificationEmblemValidMessage(GuildEmblem Alliancemblem)
    {
        this.Alliancemblem = Alliancemblem;
    }

    public AllianceModificationEmblemValidMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildEmblem Alliancemblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Alliancemblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Alliancemblem = new GuildEmblem();
        Alliancemblem.Deserialize(reader);
    }
}