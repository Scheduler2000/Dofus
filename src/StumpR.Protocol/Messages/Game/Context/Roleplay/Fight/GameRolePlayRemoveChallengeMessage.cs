using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayRemoveChallengeMessage : Message
{
    public const uint Id = 5911;

    public GameRolePlayRemoveChallengeMessage(ushort fightId)
    {
        FightId = fightId;
    }

    public GameRolePlayRemoveChallengeMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
    }
}