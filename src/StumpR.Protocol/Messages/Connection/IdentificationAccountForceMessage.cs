using StumpR.Binary;
using Version = StumpR.Protocol.Types.Version;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationAccountForceMessage : IdentificationMessage
{
    public new const uint Id = 2449;

    public IdentificationAccountForceMessage(bool autoconnect,
        bool useCertificate,
        bool useLoginToken,
        Version version,
        string lang,
        IEnumerable<sbyte> credentials,
        short serverId,
        long sessionOptionalSalt,
        IEnumerable<ushort> failedAttempts,
        string forcedAccountLogin)
    {
        Autoconnect = autoconnect;
        UseCertificate = useCertificate;
        UseLoginToken = useLoginToken;
        Version = version;
        Lang = lang;
        Credentials = credentials;
        ServerId = serverId;
        SessionOptionalSalt = sessionOptionalSalt;
        FailedAttempts = failedAttempts;
        ForcedAccountLogin = forcedAccountLogin;
    }

    public IdentificationAccountForceMessage()
    {
    }

    public override uint MessageId => Id;

    public string ForcedAccountLogin { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(ForcedAccountLogin);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ForcedAccountLogin = reader.ReadUTF();
    }
}