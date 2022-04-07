using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PlayerSearchTagInformation : AbstractPlayerSearchInformation
{
    public new const short Id = 3556;

    public PlayerSearchTagInformation(AccountTagInformation tag)
    {
        Tag = tag;
    }

    public PlayerSearchTagInformation()
    {
    }

    public override short TypeId => Id;

    public AccountTagInformation Tag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Tag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Tag = new AccountTagInformation();
        Tag.Deserialize(reader);
    }
}