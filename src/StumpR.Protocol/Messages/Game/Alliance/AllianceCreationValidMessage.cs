using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceCreationValidMessage : Message
{
    public const uint Id = 5504;

    public AllianceCreationValidMessage(string allianceName, string allianceTag, GuildEmblem allianceEmblem)
    {
        AllianceName = allianceName;
        AllianceTag = allianceTag;
        AllianceEmblem = allianceEmblem;
    }

    public AllianceCreationValidMessage()
    {
    }

    public override uint MessageId => Id;

    public string AllianceName { get; set; }

    public string AllianceTag { get; set; }

    public GuildEmblem AllianceEmblem { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(AllianceName);
        writer.WriteUTF(AllianceTag);
        AllianceEmblem.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        AllianceName = reader.ReadUTF();
        AllianceTag = reader.ReadUTF();
        AllianceEmblem = new GuildEmblem();
        AllianceEmblem.Deserialize(reader);
    }
}