using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SymbioticObjectAssociatedMessage : Message
{
    public const uint Id = 4986;

    public SymbioticObjectAssociatedMessage(uint hostUID)
    {
        HostUID = hostUID;
    }

    public SymbioticObjectAssociatedMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HostUID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HostUID);
    }

    public override void Deserialize(IDataReader reader)
    {
        HostUID = reader.ReadVarUInt();
    }
}