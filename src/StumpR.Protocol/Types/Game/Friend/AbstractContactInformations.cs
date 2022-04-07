using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AbstractContactInformations
{
    public const short Id = 6684;

    public AbstractContactInformations(int accountId, AccountTagInformation accountTag)
    {
        AccountId = accountId;
        AccountTag = accountTag;
    }

    public AbstractContactInformations()
    {
    }

    public virtual short TypeId => Id;

    public int AccountId { get; set; }

    public AccountTagInformation AccountTag { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(AccountId);
        AccountTag.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        AccountId = reader.ReadInt();
        AccountTag = new AccountTagInformation();
        AccountTag.Deserialize(reader);
    }
}