using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HouseGuildedInformations : HouseInstanceInformations
{
    public new const short Id = 856;

    public HouseGuildedInformations(bool secondHand,
        bool isLocked,
        bool hasOwner,
        bool isSaleLocked,
        int instanceId,
        AccountTagInformation ownerTag,
        long price,
        GuildInformations guildInfo)
    {
        SecondHand = secondHand;
        IsLocked = isLocked;
        HasOwner = hasOwner;
        IsSaleLocked = isSaleLocked;
        InstanceId = instanceId;
        OwnerTag = ownerTag;
        Price = price;
        GuildInfo = guildInfo;
    }

    public HouseGuildedInformations()
    {
    }

    public override short TypeId => Id;

    public GuildInformations GuildInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        GuildInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        GuildInfo = new GuildInformations();
        GuildInfo.Deserialize(reader);
    }
}