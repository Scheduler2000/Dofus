using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class OrnamentSelectedMessage : Message
{
    public const uint Id = 7637;

    public OrnamentSelectedMessage(ushort ornamentId)
    {
        OrnamentId = ornamentId;
    }

    public OrnamentSelectedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort OrnamentId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(OrnamentId);
    }

    public override void Deserialize(IDataReader reader)
    {
        OrnamentId = reader.ReadVarUShort();
    }
}