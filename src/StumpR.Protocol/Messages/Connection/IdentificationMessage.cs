using StumpR.Binary;
using Version = StumpR.Protocol.Types.Version;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationMessage : Message
{
    public const uint Id = 8915;

    public IdentificationMessage(bool autoconnect,
        bool useCertificate,
        bool useLoginToken,
        Version version,
        string lang,
        IEnumerable<sbyte> credentials,
        short serverId,
        long sessionOptionalSalt,
        IEnumerable<ushort> failedAttempts)
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
    }

    public IdentificationMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Autoconnect { get; set; }

    public bool UseCertificate { get; set; }

    public bool UseLoginToken { get; set; }

    public Version Version { get; set; }

    public string Lang { get; set; }

    public IEnumerable<sbyte> Credentials { get; set; }

    public short ServerId { get; set; }

    public long SessionOptionalSalt { get; set; }

    public IEnumerable<ushort> FailedAttempts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Autoconnect);
        flag = BooleanByteWrapper.SetFlag(flag, 1, UseCertificate);
        flag = BooleanByteWrapper.SetFlag(flag, 2, UseLoginToken);
        writer.WriteByte(flag);
        Version.Serialize(writer);
        writer.WriteUTF(Lang);
        writer.WriteVarInt(Credentials.Count());
        foreach (sbyte objectToSend in Credentials) writer.WriteSByte(objectToSend);
        writer.WriteShort(ServerId);
        writer.WriteVarLong(SessionOptionalSalt);
        writer.WriteShort((short) FailedAttempts.Count());
        foreach (ushort objectToSend in FailedAttempts) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Autoconnect = BooleanByteWrapper.GetFlag(flag, 0);
        UseCertificate = BooleanByteWrapper.GetFlag(flag, 1);
        UseLoginToken = BooleanByteWrapper.GetFlag(flag, 2);
        Version = new Version();
        Version.Deserialize(reader);
        Lang = reader.ReadUTF();
        int credentialsCount = reader.ReadVarInt();
        var credentials_ = new sbyte[credentialsCount];

        for (var credentialsIndex = 0; credentialsIndex < credentialsCount; credentialsIndex++)
            credentials_[credentialsIndex] = reader.ReadSByte();
        Credentials = credentials_;
        ServerId = reader.ReadShort();
        SessionOptionalSalt = reader.ReadVarLong();
        ushort failedAttemptsCount = reader.ReadUShort();
        var failedAttempts_ = new ushort[failedAttemptsCount];

        for (var failedAttemptsIndex = 0; failedAttemptsIndex < failedAttemptsCount; failedAttemptsIndex++)
            failedAttempts_[failedAttemptsIndex] = reader.ReadVarUShort();
        FailedAttempts = failedAttempts_;
    }
}