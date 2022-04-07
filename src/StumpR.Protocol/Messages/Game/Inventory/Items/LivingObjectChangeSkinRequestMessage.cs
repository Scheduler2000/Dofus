using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LivingObjectChangeSkinRequestMessage : Message
{
    public const uint Id = 7679;

    public LivingObjectChangeSkinRequestMessage(uint livingUID, byte livingPosition, uint skinId)
    {
        LivingUID = livingUID;
        LivingPosition = livingPosition;
        SkinId = skinId;
    }

    public LivingObjectChangeSkinRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint LivingUID { get; set; }

    public byte LivingPosition { get; set; }

    public uint SkinId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(LivingUID);
        writer.WriteByte(LivingPosition);
        writer.WriteVarUInt(SkinId);
    }

    public override void Deserialize(IDataReader reader)
    {
        LivingUID = reader.ReadVarUInt();
        LivingPosition = reader.ReadByte();
        SkinId = reader.ReadVarUInt();
    }
}