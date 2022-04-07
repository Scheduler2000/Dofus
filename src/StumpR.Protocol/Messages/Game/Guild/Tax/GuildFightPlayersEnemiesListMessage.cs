using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFightPlayersEnemiesListMessage : Message
{
    public const uint Id = 9360;

    public GuildFightPlayersEnemiesListMessage(double fightId, IEnumerable<CharacterMinimalPlusLookInformations> playerInfo)
    {
        FightId = fightId;
        PlayerInfo = playerInfo;
    }

    public GuildFightPlayersEnemiesListMessage()
    {
    }

    public override uint MessageId => Id;

    public double FightId { get; set; }

    public IEnumerable<CharacterMinimalPlusLookInformations> PlayerInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(FightId);
        writer.WriteShort((short) PlayerInfo.Count());
        foreach (CharacterMinimalPlusLookInformations objectToSend in PlayerInfo) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadDouble();
        ushort playerInfoCount = reader.ReadUShort();
        var playerInfo_ = new CharacterMinimalPlusLookInformations[playerInfoCount];

        for (var playerInfoIndex = 0; playerInfoIndex < playerInfoCount; playerInfoIndex++)
        {
            var objectToAdd = new CharacterMinimalPlusLookInformations();
            objectToAdd.Deserialize(reader);
            playerInfo_[playerInfoIndex] = objectToAdd;
        }
        PlayerInfo = playerInfo_;
    }
}