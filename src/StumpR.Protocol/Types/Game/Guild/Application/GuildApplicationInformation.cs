using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildApplicationInformation
{
    public const short Id = 7662;

    public GuildApplicationInformation(ApplicationPlayerInformation playerInfo, string applyText, double creationDate)
    {
        PlayerInfo = playerInfo;
        ApplyText = applyText;
        CreationDate = creationDate;
    }

    public GuildApplicationInformation()
    {
    }

    public virtual short TypeId => Id;

    public ApplicationPlayerInformation PlayerInfo { get; set; }

    public string ApplyText { get; set; }

    public double CreationDate { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        PlayerInfo.Serialize(writer);
        writer.WriteUTF(ApplyText);
        writer.WriteDouble(CreationDate);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        PlayerInfo = new ApplicationPlayerInformation();
        PlayerInfo.Deserialize(reader);
        ApplyText = reader.ReadUTF();
        CreationDate = reader.ReadDouble();
    }
}