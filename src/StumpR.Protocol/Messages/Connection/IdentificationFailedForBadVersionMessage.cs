using StumpR.Binary;
using Version = StumpR.Protocol.Types.Version;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
{
    public new const uint Id = 7294;

    public IdentificationFailedForBadVersionMessage(sbyte reason, Version requiredVersion)
    {
        Reason = reason;
        RequiredVersion = requiredVersion;
    }

    public IdentificationFailedForBadVersionMessage()
    {
    }

    public override uint MessageId => Id;

    public Version RequiredVersion { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        RequiredVersion.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        RequiredVersion = new Version();
        RequiredVersion.Deserialize(reader);
    }
}