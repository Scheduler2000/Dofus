using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightSummonMessage : AbstractGameActionMessage
{
    public new const uint Id = 2879;

    public GameActionFightSummonMessage(ushort actionId, double sourceId, IEnumerable<GameFightFighterInformations> summons)
    {
        ActionId = actionId;
        SourceId = sourceId;
        Summons = summons;
    }

    public GameActionFightSummonMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameFightFighterInformations> Summons { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Summons.Count());

        foreach (GameFightFighterInformations objectToSend in Summons)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort summonsCount = reader.ReadUShort();
        var summons_ = new GameFightFighterInformations[summonsCount];

        for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            summons_[summonsIndex] = objectToAdd;
        }
        Summons = summons_;
    }
}