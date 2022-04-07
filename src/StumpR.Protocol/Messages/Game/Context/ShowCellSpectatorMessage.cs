using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ShowCellSpectatorMessage : ShowCellMessage
{
    public new const uint Id = 6320;

    public ShowCellSpectatorMessage(double sourceId, ushort cellId, string playerName)
    {
        SourceId = sourceId;
        CellId = cellId;
        PlayerName = playerName;
    }

    public ShowCellSpectatorMessage()
    {
    }

    public override uint MessageId => Id;

    public string PlayerName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(PlayerName);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerName = reader.ReadUTF();
    }
}