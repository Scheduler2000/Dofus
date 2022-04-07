using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceFactsMessage : Message
{
    public const uint Id = 6820;

    public AllianceFactsMessage(AllianceFactSheetInformations infos,
        IEnumerable<GuildInAllianceInformations> guilds,
        IEnumerable<ushort> controlledSubareaIds,
        ulong leaderCharacterId,
        string leaderCharacterName)
    {
        Infos = infos;
        Guilds = guilds;
        ControlledSubareaIds = controlledSubareaIds;
        LeaderCharacterId = leaderCharacterId;
        LeaderCharacterName = leaderCharacterName;
    }

    public AllianceFactsMessage()
    {
    }

    public override uint MessageId => Id;

    public AllianceFactSheetInformations Infos { get; set; }

    public IEnumerable<GuildInAllianceInformations> Guilds { get; set; }

    public IEnumerable<ushort> ControlledSubareaIds { get; set; }

    public ulong LeaderCharacterId { get; set; }

    public string LeaderCharacterName { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Infos.TypeId);
        Infos.Serialize(writer);
        writer.WriteShort((short) Guilds.Count());
        foreach (GuildInAllianceInformations objectToSend in Guilds) objectToSend.Serialize(writer);
        writer.WriteShort((short) ControlledSubareaIds.Count());
        foreach (ushort objectToSend in ControlledSubareaIds) writer.WriteVarUShort(objectToSend);
        writer.WriteVarULong(LeaderCharacterId);
        writer.WriteUTF(LeaderCharacterName);
    }

    public override void Deserialize(IDataReader reader)
    {
        Infos = ProtocolTypeManager.GetInstance<AllianceFactSheetInformations>(reader.ReadShort());
        Infos.Deserialize(reader);
        ushort guildsCount = reader.ReadUShort();
        var guilds_ = new GuildInAllianceInformations[guildsCount];

        for (var guildsIndex = 0; guildsIndex < guildsCount; guildsIndex++)
        {
            var objectToAdd = new GuildInAllianceInformations();
            objectToAdd.Deserialize(reader);
            guilds_[guildsIndex] = objectToAdd;
        }
        Guilds = guilds_;
        ushort controlledSubareaIdsCount = reader.ReadUShort();
        var controlledSubareaIds_ = new ushort[controlledSubareaIdsCount];

        for (var controlledSubareaIdsIndex = 0; controlledSubareaIdsIndex < controlledSubareaIdsCount; controlledSubareaIdsIndex++)
            controlledSubareaIds_[controlledSubareaIdsIndex] = reader.ReadVarUShort();
        ControlledSubareaIds = controlledSubareaIds_;
        LeaderCharacterId = reader.ReadVarULong();
        LeaderCharacterName = reader.ReadUTF();
    }
}