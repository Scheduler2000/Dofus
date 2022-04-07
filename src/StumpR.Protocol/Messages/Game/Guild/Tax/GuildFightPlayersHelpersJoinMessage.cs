using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFightPlayersHelpersJoinMessage : Message
{
    public const uint Id = 4751;

    public GuildFightPlayersHelpersJoinMessage(double fightId, CharacterMinimalPlusLookInformations playerInfo)
    {
        FightId = fightId;
        PlayerInfo = playerInfo;
    }

    public GuildFightPlayersHelpersJoinMessage()
    {
    }

    public override uint MessageId => Id;

    public double FightId { get; set; }

    public CharacterMinimalPlusLookInformations PlayerInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(FightId);
        PlayerInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadDouble();
        PlayerInfo = new CharacterMinimalPlusLookInformations();
        PlayerInfo.Deserialize(reader);
    }
}