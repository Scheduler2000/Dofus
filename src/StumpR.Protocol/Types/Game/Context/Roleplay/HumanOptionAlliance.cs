using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionAlliance : HumanOption
{
    public new const short Id = 3939;

    public HumanOptionAlliance(AllianceInformations allianceInformations, sbyte aggressable)
    {
        AllianceInformations = allianceInformations;
        Aggressable = aggressable;
    }

    public HumanOptionAlliance()
    {
    }

    public override short TypeId => Id;

    public AllianceInformations AllianceInformations { get; set; }

    public sbyte Aggressable { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        AllianceInformations.Serialize(writer);
        writer.WriteSByte(Aggressable);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        AllianceInformations = new AllianceInformations();
        AllianceInformations.Deserialize(reader);
        Aggressable = reader.ReadSByte();
    }
}