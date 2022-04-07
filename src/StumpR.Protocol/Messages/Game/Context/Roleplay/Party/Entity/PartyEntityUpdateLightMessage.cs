using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyEntityUpdateLightMessage : PartyUpdateLightMessage
{
    public new const uint Id = 6677;

    public PartyEntityUpdateLightMessage(uint partyId,
        ulong objectId,
        uint lifePoints,
        uint maxLifePoints,
        ushort prospecting,
        byte regenRate,
        sbyte indexId)
    {
        PartyId = partyId;
        ObjectId = objectId;
        LifePoints = lifePoints;
        MaxLifePoints = maxLifePoints;
        Prospecting = prospecting;
        RegenRate = regenRate;
        IndexId = indexId;
    }

    public PartyEntityUpdateLightMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte IndexId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(IndexId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        IndexId = reader.ReadSByte();
    }
}