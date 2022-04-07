using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
{
    public new const uint Id = 7340;

    public PartyInvitationDungeonDetailsMessage(uint partyId,
        sbyte partyType,
        string partyName,
        ulong fromId,
        string fromName,
        ulong leaderId,
        IEnumerable<PartyInvitationMemberInformations> members,
        IEnumerable<PartyGuestInformations> guests,
        ushort dungeonId,
        IEnumerable<bool> playersDungeonReady)
    {
        PartyId = partyId;
        PartyType = partyType;
        PartyName = partyName;
        FromId = fromId;
        FromName = fromName;
        LeaderId = leaderId;
        Members = members;
        Guests = guests;
        DungeonId = dungeonId;
        PlayersDungeonReady = playersDungeonReady;
    }

    public PartyInvitationDungeonDetailsMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort DungeonId { get; set; }

    public IEnumerable<bool> PlayersDungeonReady { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(DungeonId);
        writer.WriteShort((short) PlayersDungeonReady.Count());
        foreach (bool objectToSend in PlayersDungeonReady) writer.WriteBoolean(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        DungeonId = reader.ReadVarUShort();
        ushort playersDungeonReadyCount = reader.ReadUShort();
        var playersDungeonReady_ = new bool[playersDungeonReadyCount];

        for (var playersDungeonReadyIndex = 0; playersDungeonReadyIndex < playersDungeonReadyCount; playersDungeonReadyIndex++)
            playersDungeonReady_[playersDungeonReadyIndex] = reader.ReadBoolean();
        PlayersDungeonReady = playersDungeonReady_;
    }
}