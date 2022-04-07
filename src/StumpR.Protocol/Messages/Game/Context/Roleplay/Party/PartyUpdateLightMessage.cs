using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyUpdateLightMessage : AbstractPartyEventMessage
{
    public new const uint Id = 585;

    public PartyUpdateLightMessage(uint partyId, ulong objectId, uint lifePoints, uint maxLifePoints, ushort prospecting, byte regenRate)
    {
        PartyId = partyId;
        ObjectId = objectId;
        LifePoints = lifePoints;
        MaxLifePoints = maxLifePoints;
        Prospecting = prospecting;
        RegenRate = regenRate;
    }

    public PartyUpdateLightMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ObjectId { get; set; }

    public uint LifePoints { get; set; }

    public uint MaxLifePoints { get; set; }

    public ushort Prospecting { get; set; }

    public byte RegenRate { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(ObjectId);
        writer.WriteVarUInt(LifePoints);
        writer.WriteVarUInt(MaxLifePoints);
        writer.WriteVarUShort(Prospecting);
        writer.WriteByte(RegenRate);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectId = reader.ReadVarULong();
        LifePoints = reader.ReadVarUInt();
        MaxLifePoints = reader.ReadVarUInt();
        Prospecting = reader.ReadVarUShort();
        RegenRate = reader.ReadByte();
    }
}