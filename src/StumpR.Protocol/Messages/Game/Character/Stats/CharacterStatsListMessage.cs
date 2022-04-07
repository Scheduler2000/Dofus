using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CharacterStatsListMessage : Message
{
    public const uint Id = 2227;

    public CharacterStatsListMessage(CharacterCharacteristicsInformations stats)
    {
        Stats = stats;
    }

    public CharacterStatsListMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterCharacteristicsInformations Stats { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Stats.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Stats = new CharacterCharacteristicsInformations();
        Stats.Deserialize(reader);
    }
}