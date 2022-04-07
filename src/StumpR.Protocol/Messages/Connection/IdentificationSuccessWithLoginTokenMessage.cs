using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
{
    public new const uint Id = 2204;

    public IdentificationSuccessWithLoginTokenMessage(bool hasRights,
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
        byte havenbagAvailableRoom,
        string loginToken)
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
        LoginToken = loginToken;
    }

    public IdentificationSuccessWithLoginTokenMessage()
    {
    }

    public override uint MessageId => Id;

    public string LoginToken { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(LoginToken);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LoginToken = reader.ReadUTF();
    }
}