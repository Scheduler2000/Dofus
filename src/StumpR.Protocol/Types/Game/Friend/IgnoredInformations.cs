using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class IgnoredInformations : AbstractContactInformations
{
    public new const short Id = 1909;

    public IgnoredInformations(int accountId, AccountTagInformation accountTag)
    {
        AccountId = accountId;
        AccountTag = accountTag;
    }

    public IgnoredInformations()
    {
    }

    public override short TypeId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}