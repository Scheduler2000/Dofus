using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseGuildRightsMessage : Message
{
    public const uint Id = 5258;

    public HouseGuildRightsMessage(uint houseId, int instanceId, bool secondHand, GuildInformations guildInfo, uint rights)
    {
        HouseId = houseId;
        InstanceId = instanceId;
        SecondHand = secondHand;
        GuildInfo = guildInfo;
        Rights = rights;
    }

    public HouseGuildRightsMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public int InstanceId { get; set; }

    public bool SecondHand { get; set; }

    public GuildInformations GuildInfo { get; set; }

    public uint Rights { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HouseId);
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(SecondHand);
        GuildInfo.Serialize(writer);
        writer.WriteVarUInt(Rights);
    }

    public override void Deserialize(IDataReader reader)
    {
        HouseId = reader.ReadVarUInt();
        InstanceId = reader.ReadInt();
        SecondHand = reader.ReadBoolean();
        GuildInfo = new GuildInformations();
        GuildInfo.Deserialize(reader);
        Rights = reader.ReadVarUInt();
    }
}