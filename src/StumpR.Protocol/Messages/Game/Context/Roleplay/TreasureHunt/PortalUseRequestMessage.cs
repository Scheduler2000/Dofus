using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PortalUseRequestMessage : Message
{
    public const uint Id = 1831;

    public PortalUseRequestMessage(uint portalId)
    {
        PortalId = portalId;
    }

    public PortalUseRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint PortalId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(PortalId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PortalId = reader.ReadVarUInt();
    }
}