using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PlayerStatusExtended : PlayerStatus
{
    public new const short Id = 1176;

    public PlayerStatusExtended(sbyte statusId, string message)
    {
        StatusId = statusId;
        Message = message;
    }

    public PlayerStatusExtended()
    {
    }

    public override short TypeId => Id;

    public string Message { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Message);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Message = reader.ReadUTF();
    }
}