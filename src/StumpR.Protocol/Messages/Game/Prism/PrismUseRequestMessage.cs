using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismUseRequestMessage : Message
{
    public const uint Id = 8164;

    public PrismUseRequestMessage(sbyte moduleToUse)
    {
        ModuleToUse = moduleToUse;
    }

    public PrismUseRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ModuleToUse { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(ModuleToUse);
    }

    public override void Deserialize(IDataReader reader)
    {
        ModuleToUse = reader.ReadSByte();
    }
}