using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class KohUpdateMessage : Message
{
    public const uint Id = 6530;

    public KohUpdateMessage(IEnumerable<AllianceInformations> alliances,
        IEnumerable<ushort> allianceNbMembers,
        IEnumerable<uint> allianceRoundWeigth,
        IEnumerable<byte> allianceMatchScore,
        IEnumerable<BasicAllianceInformations> allianceMapWinners,
        uint allianceMapWinnerScore,
        uint allianceMapMyAllianceScore,
        double nextTickTime)
    {
        Alliances = alliances;
        AllianceNbMembers = allianceNbMembers;
        AllianceRoundWeigth = allianceRoundWeigth;
        AllianceMatchScore = allianceMatchScore;
        AllianceMapWinners = allianceMapWinners;
        AllianceMapWinnerScore = allianceMapWinnerScore;
        AllianceMapMyAllianceScore = allianceMapMyAllianceScore;
        NextTickTime = nextTickTime;
    }

    public KohUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AllianceInformations> Alliances { get; set; }

    public IEnumerable<ushort> AllianceNbMembers { get; set; }

    public IEnumerable<uint> AllianceRoundWeigth { get; set; }

    public IEnumerable<byte> AllianceMatchScore { get; set; }

    public IEnumerable<BasicAllianceInformations> AllianceMapWinners { get; set; }

    public uint AllianceMapWinnerScore { get; set; }

    public uint AllianceMapMyAllianceScore { get; set; }

    public double NextTickTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Alliances.Count());
        foreach (AllianceInformations objectToSend in Alliances) objectToSend.Serialize(writer);
        writer.WriteShort((short) AllianceNbMembers.Count());
        foreach (ushort objectToSend in AllianceNbMembers) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) AllianceRoundWeigth.Count());
        foreach (uint objectToSend in AllianceRoundWeigth) writer.WriteVarUInt(objectToSend);
        writer.WriteShort((short) AllianceMatchScore.Count());
        foreach (byte objectToSend in AllianceMatchScore) writer.WriteByte(objectToSend);
        writer.WriteShort((short) AllianceMapWinners.Count());
        foreach (BasicAllianceInformations objectToSend in AllianceMapWinners) objectToSend.Serialize(writer);
        writer.WriteVarUInt(AllianceMapWinnerScore);
        writer.WriteVarUInt(AllianceMapMyAllianceScore);
        writer.WriteDouble(NextTickTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort alliancesCount = reader.ReadUShort();
        var alliances_ = new AllianceInformations[alliancesCount];

        for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
        {
            var objectToAdd = new AllianceInformations();
            objectToAdd.Deserialize(reader);
            alliances_[alliancesIndex] = objectToAdd;
        }
        Alliances = alliances_;
        ushort allianceNbMembersCount = reader.ReadUShort();
        var allianceNbMembers_ = new ushort[allianceNbMembersCount];

        for (var allianceNbMembersIndex = 0; allianceNbMembersIndex < allianceNbMembersCount; allianceNbMembersIndex++)
            allianceNbMembers_[allianceNbMembersIndex] = reader.ReadVarUShort();
        AllianceNbMembers = allianceNbMembers_;
        ushort allianceRoundWeigthCount = reader.ReadUShort();
        var allianceRoundWeigth_ = new uint[allianceRoundWeigthCount];

        for (var allianceRoundWeigthIndex = 0; allianceRoundWeigthIndex < allianceRoundWeigthCount; allianceRoundWeigthIndex++)
            allianceRoundWeigth_[allianceRoundWeigthIndex] = reader.ReadVarUInt();
        AllianceRoundWeigth = allianceRoundWeigth_;
        ushort allianceMatchScoreCount = reader.ReadUShort();
        var allianceMatchScore_ = new byte[allianceMatchScoreCount];

        for (var allianceMatchScoreIndex = 0; allianceMatchScoreIndex < allianceMatchScoreCount; allianceMatchScoreIndex++)
            allianceMatchScore_[allianceMatchScoreIndex] = reader.ReadByte();
        AllianceMatchScore = allianceMatchScore_;
        ushort allianceMapWinnersCount = reader.ReadUShort();
        var allianceMapWinners_ = new BasicAllianceInformations[allianceMapWinnersCount];

        for (var allianceMapWinnersIndex = 0; allianceMapWinnersIndex < allianceMapWinnersCount; allianceMapWinnersIndex++)
        {
            var objectToAdd = new BasicAllianceInformations();
            objectToAdd.Deserialize(reader);
            allianceMapWinners_[allianceMapWinnersIndex] = objectToAdd;
        }
        AllianceMapWinners = allianceMapWinners_;
        AllianceMapWinnerScore = reader.ReadVarUInt();
        AllianceMapMyAllianceScore = reader.ReadVarUInt();
        NextTickTime = reader.ReadDouble();
    }
}