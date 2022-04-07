using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationSuccessMessage : Message
{
    public const uint Id = 331;

    public IdentificationSuccessMessage(bool hasRights,
        bool hasConsoleRight,
        bool wasAlreadyConnected,
        string login,
        AccountTagInformation accountTag,
        int accountId,
        sbyte communityId,
        string secretQuestion,
        double accountCreation,
        double subscriptionElapsedDuration,
        double subscriptionEndDate,
        byte havenbagAvailableRoom)
    {
        HasRights = hasRights;
        HasConsoleRight = hasConsoleRight;
        WasAlreadyConnected = wasAlreadyConnected;
        Login = login;
        AccountTag = accountTag;
        AccountId = accountId;
        CommunityId = communityId;
        SecretQuestion = secretQuestion;
        AccountCreation = accountCreation;
        SubscriptionElapsedDuration = subscriptionElapsedDuration;
        SubscriptionEndDate = subscriptionEndDate;
        HavenbagAvailableRoom = havenbagAvailableRoom;
    }

    public IdentificationSuccessMessage()
    {
    }

    public override uint MessageId => Id;

    public bool HasRights { get; set; }

    public bool HasConsoleRight { get; set; }

    public bool WasAlreadyConnected { get; set; }

    public string Login { get; set; }

    public AccountTagInformation AccountTag { get; set; }

    public int AccountId { get; set; }

    public sbyte CommunityId { get; set; }

    public string SecretQuestion { get; set; }

    public double AccountCreation { get; set; }

    public double SubscriptionElapsedDuration { get; set; }

    public double SubscriptionEndDate { get; set; }

    public byte HavenbagAvailableRoom { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, HasRights);
        flag = BooleanByteWrapper.SetFlag(flag, 1, HasConsoleRight);
        flag = BooleanByteWrapper.SetFlag(flag, 2, WasAlreadyConnected);
        writer.WriteByte(flag);
        writer.WriteUTF(Login);
        AccountTag.Serialize(writer);
        writer.WriteInt(AccountId);
        writer.WriteSByte(CommunityId);
        writer.WriteUTF(SecretQuestion);
        writer.WriteDouble(AccountCreation);
        writer.WriteDouble(SubscriptionElapsedDuration);
        writer.WriteDouble(SubscriptionEndDate);
        writer.WriteByte(HavenbagAvailableRoom);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        HasRights = BooleanByteWrapper.GetFlag(flag, 0);
        HasConsoleRight = BooleanByteWrapper.GetFlag(flag, 1);
        WasAlreadyConnected = BooleanByteWrapper.GetFlag(flag, 2);
        Login = reader.ReadUTF();
        AccountTag = new AccountTagInformation();
        AccountTag.Deserialize(reader);
        AccountId = reader.ReadInt();
        CommunityId = reader.ReadSByte();
        SecretQuestion = reader.ReadUTF();
        AccountCreation = reader.ReadDouble();
        SubscriptionElapsedDuration = reader.ReadDouble();
        SubscriptionEndDate = reader.ReadDouble();
        HavenbagAvailableRoom = reader.ReadByte();
    }
}