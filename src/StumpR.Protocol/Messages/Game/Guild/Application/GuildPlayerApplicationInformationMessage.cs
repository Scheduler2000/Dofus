using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildPlayerApplicationInformationMessage : GuildPlayerApplicationAbstractMessage
{
    public new const uint Id = 9380;

    public GuildPlayerApplicationInformationMessage(GuildInformations guildInformation, GuildApplicationInformation apply)
    {
        GuildInformation = guildInformation;
        Apply = apply;
    }

    public GuildPlayerApplicationInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildInformations GuildInformation { get; set; }

    public GuildApplicationInformation Apply { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        GuildInformation.Serialize(writer);
        Apply.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        GuildInformation = new GuildInformations();
        GuildInformation.Deserialize(reader);
        Apply = new GuildApplicationInformation();
        Apply.Deserialize(reader);
    }
}