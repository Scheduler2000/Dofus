using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceInsiderInfoMessage : Message
{
    public const uint Id = 3553;

    public AllianceInsiderInfoMessage(AllianceFactSheetInformations allianceInfos,
        IEnumerable<GuildInsiderFactSheetInformations> guilds,
        IEnumerable<PrismSubareaEmptyInfo> prisms)
    {
        AllianceInfos = allianceInfos;
        Guilds = guilds;
        Prisms = prisms;
    }

    public AllianceInsiderInfoMessage()
    {
    }

    public override uint MessageId => Id;

    public AllianceFactSheetInformations AllianceInfos { get; set; }

    public IEnumerable<GuildInsiderFactSheetInformations> Guilds { get; set; }

    public IEnumerable<PrismSubareaEmptyInfo> Prisms { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        AllianceInfos.Serialize(writer);
        writer.WriteShort((short) Guilds.Count());
        foreach (GuildInsiderFactSheetInformations objectToSend in Guilds) objectToSend.Serialize(writer);
        writer.WriteShort((short) Prisms.Count());

        foreach (PrismSubareaEmptyInfo objectToSend in Prisms)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        AllianceInfos = new AllianceFactSheetInformations();
        AllianceInfos.Deserialize(reader);
        ushort guildsCount = reader.ReadUShort();
        var guilds_ = new GuildInsiderFactSheetInformations[guildsCount];

        for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
        {
            var objectToAdd = new GuildInsiderFactSheetInformations();
            objectToAdd.Deserialize(reader);
            guilds_[guildsIndex] = objectToAdd;
        }
        Guilds = guilds_;
        ushort prismsCount = reader.ReadUShort();
        var prisms_ = new PrismSubareaEmptyInfo[prismsCount];

        for (var prismsIndex = 0; prismsIndex < prismsCount; prismsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            prisms_[prismsIndex] = objectToAdd;
        }
        Prisms = prisms_;
    }
}