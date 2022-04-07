using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SymbioticObjectAssociateRequestMessage : Message
{
    public const uint Id = 7604;

    public SymbioticObjectAssociateRequestMessage(uint symbioteUID, byte symbiotePos, uint hostUID, byte hostPos)
    {
        SymbioteUID = symbioteUID;
        SymbiotePos = symbiotePos;
        HostUID = hostUID;
        HostPos = hostPos;
    }

    public SymbioticObjectAssociateRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint SymbioteUID { get; set; }

    public byte SymbiotePos { get; set; }

    public uint HostUID { get; set; }

    public byte HostPos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(SymbioteUID);
        writer.WriteByte(SymbiotePos);
        writer.WriteVarUInt(HostUID);
        writer.WriteByte(HostPos);
    }

    public override void Deserialize(IDataReader reader)
    {
        SymbioteUID = reader.ReadVarUInt();
        SymbiotePos = reader.ReadByte();
        HostUID = reader.ReadVarUInt();
        HostPos = reader.ReadByte();
    }
}