using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismSettingsRequestMessage : Message
{
    public const uint Id = 8342;

    public PrismSettingsRequestMessage(ushort subAreaId, sbyte startDefenseTime)
    {
        SubAreaId = subAreaId;
        StartDefenseTime = startDefenseTime;
    }

    public PrismSettingsRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public sbyte StartDefenseTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteSByte(StartDefenseTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        StartDefenseTime = reader.ReadSByte();
    }
}