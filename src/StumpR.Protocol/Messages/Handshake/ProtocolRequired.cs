using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ProtocolRequired : Message
{
    public const uint Id = 5716;

    public ProtocolRequired(string version)
    {
        Version = version;
    }

    public ProtocolRequired()
    {
    }

    public override uint MessageId => Id;

    public string Version { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Version);
    }

    public override void Deserialize(IDataReader reader)
    {
        Version = reader.ReadUTF();
    }
}