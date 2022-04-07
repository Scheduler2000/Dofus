using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightMultipleSummonMessage : AbstractGameActionMessage
{
    public new const uint Id = 710;

    public GameActionFightMultipleSummonMessage(ushort actionId, double sourceId, IEnumerable<GameContextSummonsInformation> summons)
    {
        ActionId = actionId;
        SourceId = sourceId;
        Summons = summons;
    }

    public GameActionFightMultipleSummonMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameContextSummonsInformation> Summons { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Summons.Count());

        foreach (GameContextSummonsInformation objectToSend in Summons)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort summonsCount = reader.ReadUShort();
        var summons_ = new GameContextSummonsInformation[summonsCount];

        for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameContextSummonsInformation>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            summons_[summonsIndex] = objectToAdd;
        }
        Summons = summons_;
    }
}