using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class UpdateRecruitmentInformationMessage : Message
{
    public const uint Id = 3169;

    public UpdateRecruitmentInformationMessage(GuildRecruitmentInformation recruitmentData)
    {
        RecruitmentData = recruitmentData;
    }

    public UpdateRecruitmentInformationMessage()
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