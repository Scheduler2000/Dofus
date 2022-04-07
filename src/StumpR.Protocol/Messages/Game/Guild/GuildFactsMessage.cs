using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFactsMessage : Message
{
    public const uint Id = 2464;

    public GuildFactsMessage(GuildFactSheetInformations infos,
        int creationDate,
        ushort nbTaxCollectors,
        IEnumerable<CharacterMinimalGuildPublicInformations> members)
    {
        Infos = infos;
        CreationDate = creationDate;
        NbTaxCollectors = nbTaxCollectors;
        Members = members;
    }

    public GuildFactsMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildFactSheetInformations Infos { get; set; }

    public int CreationDate { get; set; }

    public ushort NbTaxCollectors { get; set; }

    public IEnumerable<CharacterMinimalGuildPublicInformations> Members { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Infos.TypeId);
        Infos.Serialize(writer);
        writer.WriteInt(CreationDate);
        writer.WriteVarUShort(NbTaxCollectors);
        writer.WriteShort((short) Members.Count());
        foreach (CharacterMinimalGuildPublicInformations objectToSend in Members) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Infos = ProtocolTypeManager.GetInstance<GuildFactSheetInformations>(reader.ReadShort());
        Infos.Deserialize(reader);
        CreationDate = reader.ReadInt();
        NbTaxCollectors = reader.ReadVarUShort();
        ushort membersCount = reader.ReadUShort();
        var members_ = new CharacterMinimalGuildPublicInformations[membersCount];

        for (var membersIndex = 0; membersIndex < membersCount; membersIndex++)
        {
            var objectToAdd = new CharacterMinimalGuildPublicInformations();
            objectToAdd.Deserialize(reader);
            members_[membersIndex] = objectToAdd;
        }
        Members = members_;
    }
}