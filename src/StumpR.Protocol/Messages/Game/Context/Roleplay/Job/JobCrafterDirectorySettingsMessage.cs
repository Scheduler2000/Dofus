using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class JobCrafterDirectorySettingsMessage : Message
{
    public const uint Id = 8518;

    public JobCrafterDirectorySettingsMessage(IEnumerable<JobCrafterDirectorySettings> craftersSettings)
    {
        CraftersSettings = craftersSettings;
    }

    public JobCrafterDirectorySettingsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<JobCrafterDirectorySettings> CraftersSettings { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) CraftersSettings.Count());
        foreach (JobCrafterDirectorySettings objectToSend in CraftersSettings) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort craftersSettingsCount = reader.ReadUShort();
        var craftersSettings_ = new JobCrafterDirectorySettings[craftersSettingsCount];

        for (var craftersSettingsIndex = 0; craftersSettingsIndex < craftersSettingsCount; craftersSettingsIndex++)
        {
            var objectToAdd = new JobCrafterDirectorySettings();
            objectToAdd.Deserialize(reader);
            craftersSettings_[craftersSettingsIndex] = objectToAdd;
        }
        CraftersSettings = craftersSettings_;
    }
}