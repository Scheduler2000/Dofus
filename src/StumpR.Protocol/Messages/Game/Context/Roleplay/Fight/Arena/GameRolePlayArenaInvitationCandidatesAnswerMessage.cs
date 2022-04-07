using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaInvitationCandidatesAnswerMessage : Message
{
    public const uint Id = 4913;

    public GameRolePlayArenaInvitationCandidatesAnswerMessage(IEnumerable<LeagueFriendInformations> candidates)
    {
        Candidates = candidates;
    }

    public GameRolePlayArenaInvitationCandidatesAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<LeagueFriendInformations> Candidates { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Candidates.Count());
        foreach (LeagueFriendInformations objectToSend in Candidates) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort candidatesCount = reader.ReadUShort();
        var candidates_ = new LeagueFriendInformations[candidatesCount];

        for (var candidatesIndex = 0; candidatesIndex < candidatesCount; candidatesIndex++)
        {
            var objectToAdd = new LeagueFriendInformations();
            objectToAdd.Deserialize(reader);
            candidates_[candidatesIndex] = objectToAdd;
        }
        Candidates = candidates_;
    }
}