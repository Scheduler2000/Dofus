using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaUpdatePlayerInfosMessage : Message
{
    public const uint Id = 8202;

    public GameRolePlayArenaUpdatePlayerInfosMessage(ArenaRankInfos solo)
    {
        Solo = solo;
    }

    public GameRolePlayArenaUpdatePlayerInfosMessage()
    {
    }

    public override uint MessageId => Id;

    public ArenaRankInfos Solo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Solo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Solo = new ArenaRankInfos();
        Solo.Deserialize(reader);
    }
}