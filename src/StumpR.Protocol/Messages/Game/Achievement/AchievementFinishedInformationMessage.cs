using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementFinishedInformationMessage : AchievementFinishedMessage
{
    public new const uint Id = 9768;

    public AchievementFinishedInformationMessage(AchievementAchievedRewardable achievement, string name, ulong playerId)
    {
        Achievement = achievement;
        Name = name;
        PlayerId = playerId;
    }

    public AchievementFinishedInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public string Name { get; set; }

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteUTF(Name);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Name = reader.ReadUTF();
        PlayerId = reader.ReadVarULong();
    }
}