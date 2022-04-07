using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapRunningFightDetailsMessage : Message
{
    public const uint Id = 3380;

    public MapRunningFightDetailsMessage(ushort fightId,
        IEnumerable<GameFightFighterLightInformations> attackers,
        IEnumerable<GameFightFighterLightInformations> defenders)
    {
        FightId = fightId;
        Attackers = attackers;
        Defenders = defenders;
    }

    public MapRunningFightDetailsMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public IEnumerable<GameFightFighterLightInformations> Attackers { get; set; }

    public IEnumerable<GameFightFighterLightInformations> Defenders { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteShort((short) Attackers.Count());

        foreach (GameFightFighterLightInformations objectToSend in Attackers)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) Defenders.Count());

        foreach (GameFightFighterLightInformations objectToSend in Defenders)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        ushort attackersCount = reader.ReadUShort();
        var attackers_ = new GameFightFighterLightInformations[attackersCount];

        for (var attackersIndex = 0; attackersIndex < attackersCount; attackersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            attackers_[attackersIndex] = objectToAdd;
        }
        Attackers = attackers_;
        ushort defendersCount = reader.ReadUShort();
        var defenders_ = new GameFightFighterLightInformations[defendersCount];

        for (var defendersIndex = 0; defendersIndex < defendersCount; defendersIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            defenders_[defendersIndex] = objectToAdd;
        }
        Defenders = defenders_;
    }
}