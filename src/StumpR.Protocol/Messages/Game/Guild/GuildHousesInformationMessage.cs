using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildHousesInformationMessage : Message
{
    public const uint Id = 9308;

    public GuildHousesInformationMessage(IEnumerable<HouseInformationsForGuild> housesInformations)
    {
        HousesInformations = housesInformations;
    }

    public GuildHousesInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<HouseInformationsForGuild> HousesInformations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) HousesInformations.Count());
        foreach (HouseInformationsForGuild objectToSend in HousesInformations) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort housesInformationsCount = reader.ReadUShort();
        var housesInformations_ = new HouseInformationsForGuild[housesInformationsCount];

        for (var housesInformationsIndex = 0; housesInformationsIndex < housesInformationsCount; housesInformationsIndex++)
        {
            var objectToAdd = new HouseInformationsForGuild();
            objectToAdd.Deserialize(reader);
            housesInformations_[housesInformationsIndex] = objectToAdd;
        }
        HousesInformations = housesInformations_;
    }
}