using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicWhoIsMessage : Message
{
    public const uint Id = 7169;

    public BasicWhoIsMessage(bool self,
        bool verbose,
        sbyte position,
        AccountTagInformation accountTag,
        int accountId,
        string playerName,
        ulong playerId,
        short areaId,
        short serverId,
        short originServerId,
        IEnumerable<AbstractSocialGroupInfos> socialGroups,
        sbyte playerState)
    {
        Self = self;
        Verbose = verbose;
        Position = position;
        AccountTag = accountTag;
        AccountId = accountId;
        PlayerName = playerName;
        PlayerId = playerId;
        AreaId = areaId;
        ServerId = serverId;
        OriginServerId = originServerId;
        SocialGroups = socialGroups;
        PlayerState = playerState;
    }

    public BasicWhoIsMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Self { get; set; }

    public bool Verbose { get; set; }

    public sbyte Position { get; set; }

    public AccountTagInformation AccountTag { get; set; }

    public int AccountId { get; set; }

    public string PlayerName { get; set; }

    public ulong PlayerId { get; set; }

    public short AreaId { get; set; }

    public short ServerId { get; set; }

    public short OriginServerId { get; set; }

    public IEnumerable<AbstractSocialGroupInfos> SocialGroups { get; set; }

    public sbyte PlayerState { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Self);
        flag = BooleanByteWrapper.SetFlag(flag, 1, Verbose);
        writer.WriteByte(flag);
        writer.WriteSByte(Position);
        AccountTag.Serialize(writer);
        writer.WriteInt(AccountId);
        writer.WriteUTF(PlayerName);
        writer.WriteVarULong(PlayerId);
        writer.WriteShort(AreaId);
        writer.WriteShort(ServerId);
        writer.WriteShort(OriginServerId);
        writer.WriteShort((short) SocialGroups.Count());

        foreach (AbstractSocialGroupInfos objectToSend in SocialGroups)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteSByte(PlayerState);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        Self = BooleanByteWrapper.GetFlag(flag, 0);
        Verbose = BooleanByteWrapper.GetFlag(flag, 1);
        Position = reader.ReadSByte();
        AccountTag = new AccountTagInformation();
        AccountTag.Deserialize(reader);
        AccountId = reader.ReadInt();
        PlayerName = reader.ReadUTF();
        PlayerId = reader.ReadVarULong();
        AreaId = reader.ReadShort();
        ServerId = reader.ReadShort();
        OriginServerId = reader.ReadShort();
        ushort socialGroupsCount = reader.ReadUShort();
        var socialGroups_ = new AbstractSocialGroupInfos[socialGroupsCount];

        for (var socialGroupsIndex = 0; socialGroupsIndex < socialGroupsCount; socialGroupsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<AbstractSocialGroupInfos>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            socialGroups_[socialGroupsIndex] = objectToAdd;
        }
        SocialGroups = socialGroups_;
        PlayerState = reader.ReadSByte();
    }
}