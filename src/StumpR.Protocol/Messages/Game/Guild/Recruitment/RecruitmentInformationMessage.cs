using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class RecruitmentInformationMessage : Message
{
    public const uint Id = 3164;

    public RecruitmentInformationMessage(GuildRecruitmentInformation recruitmentData)
    {
        RecruitmentData = recruitmentData;
    }

    public RecruitmentInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildRecruitmentInformation RecruitmentData { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        RecruitmentData.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        RecruitmentData = new GuildRecruitmentInformation();
        RecruitmentData.Deserialize(reader);
    }
}