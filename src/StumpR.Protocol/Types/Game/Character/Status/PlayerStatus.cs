using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PlayerStatus
{
    public const short Id = 3077;

    public PlayerStatus(sbyte statusId)
    {
        StatusId = statusId;
    }

    public PlayerStatus()
    {
    }

    public virtual short TypeId => Id;

    public sbyte StatusId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(StatusId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        StatusId = reader.ReadSByte();
    }
}