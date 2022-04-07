using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectoryDefineSettingsMessage : Message
{
    public const uint Id = 6260;

    public JobCrafterDirectoryDefineSettingsMessage(JobCrafterDirectorySettings settings)
    {
        Settings = settings;
    }

    public JobCrafterDirectoryDefineSettingsMessage()
    {
    }

    public override uint MessageId => Id;

    public JobCrafterDirectorySettings Settings { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Settings.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Settings = new JobCrafterDirectorySettings();
        Settings.Deserialize(reader);
    }
}