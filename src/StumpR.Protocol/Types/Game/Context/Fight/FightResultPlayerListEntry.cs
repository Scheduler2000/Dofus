using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightResultPlayerListEntry : FightResultFighterListEntry
{
    public new const short Id = 9771;

    public FightResultPlayerListEntry(ushort outcome,
        sbyte wave,
        FightLoot rewards,
        double objectId,
        bool alive,
        ushort level,
        IEnumerable<FightResultAdditionalData> additional)
    {
        Outcome = outcome;
        Wave = wave;
        Rewards = rewards;
        ObjectId = objectId;
        Alive = alive;
        Level = level;
        Additional = additional;
    }

    public FightResultPlayerListEntry()
    {
    }

    public override short TypeId => Id;

    public ushort Level { get; set; }

    public IEnumerable<FightResultAdditionalData> Additional { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Level);
        writer.WriteShort((short) Additional.Count());

        foreach (FightResultAdditionalData objectToSend in Additional)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Level = reader.ReadVarUShort();
        ushort additionalCount = reader.ReadUShort();
        var additional_ = new FightResultAdditionalData[additionalCount];

        for (var additionalIndex = 0; additionalIndex < additionalCount; additionalIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<FightResultAdditionalData>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            additional_[additionalIndex] = objectToAdd;
        }
        Additional = additional_;
    }
}