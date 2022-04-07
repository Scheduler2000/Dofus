using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorWaitingForHelpInformations : TaxCollectorComplementaryInformations
{
    public new const short Id = 3199;

    public TaxCollectorWaitingForHelpInformations(ProtectedEntityWaitingForHelpInfo waitingForHelpInfo)
    {
        WaitingForHelpInfo = waitingForHelpInfo;
    }

    public TaxCollectorWaitingForHelpInformations()
    {
    }

    public override short TypeId => Id;

    public ProtectedEntityWaitingForHelpInfo WaitingForHelpInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        WaitingForHelpInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        WaitingForHelpInfo = new ProtectedEntityWaitingForHelpInfo();
        WaitingForHelpInfo.Deserialize(reader);
    }
}