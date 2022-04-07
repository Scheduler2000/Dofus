using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildHouseUpdateInformationMessage : Message
{
    public const uint Id = 6703;

    public GuildHouseUpdateInformationMessage(HouseInformationsForGuild housesInformations)
    {
        HousesInformations = housesInformations;
    }

    public GuildHouseUpdateInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public HouseInformationsForGuild HousesInformations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        HousesInformations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        HousesInformations = new HouseInformationsForGuild();
        HousesInformations.Deserialize(reader);
    }
}