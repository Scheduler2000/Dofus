using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildApplicationIsAnsweredMessage : Message
{
    public const uint Id = 33;

    public GuildApplicationIsAnsweredMessage(bool accepted, GuildInformations guildInformation)
    {
        Accepted = accepted;
        GuildInformation = guildInformation;
    }

    public GuildApplicationIsAnsweredMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Accepted { get; set; }

    public GuildInformations GuildInformation { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Accepted);
        GuildInformation.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Accepted = reader.ReadBoolean();
        GuildInformation = new GuildInformations();
        GuildInformation.Deserialize(reader);
    }
}