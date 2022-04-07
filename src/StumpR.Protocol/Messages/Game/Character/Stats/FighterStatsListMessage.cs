using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FighterStatsListMessage : Message
{
    public const uint Id = 534;

    public FighterStatsListMessage(CharacterCharacteristicsInformations stats)
    {
        Stats = stats;
    }

    public FighterStatsListMessage()
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