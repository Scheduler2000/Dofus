using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LivingObjectDissociateMessage : Message
{
    public const uint Id = 9254;

    public LivingObjectDissociateMessage(uint livingUID, byte livingPosition)
    {
        LivingUID = livingUID;
        LivingPosition = livingPosition;
    }

    public LivingObjectDissociateMessage()
    {
    }

    public override uint MessageId => Id;

    public uint LivingUID { get; set; }

    public byte LivingPosition { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(LivingUID);
        writer.WriteByte(LivingPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
        LivingUID = reader.ReadVarUInt();
        LivingPosition = reader.ReadByte();
    }
}