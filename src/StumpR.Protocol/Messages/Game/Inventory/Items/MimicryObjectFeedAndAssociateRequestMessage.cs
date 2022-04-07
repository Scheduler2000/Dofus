using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MimicryObjectFeedAndAssociateRequestMessage : SymbioticObjectAssociateRequestMessage
{
    public new const uint Id = 2549;

    public MimicryObjectFeedAndAssociateRequestMessage(uint symbioteUID,
        byte symbiotePos,
        uint hostUID,
        byte hostPos,
        uint foodUID,
        byte foodPos,
        bool preview)
    {
        SymbioteUID = symbioteUID;
        SymbiotePos = symbiotePos;
        HostUID = hostUID;
        HostPos = hostPos;
        FoodUID = foodUID;
        FoodPos = foodPos;
        Preview = preview;
    }

    public MimicryObjectFeedAndAssociateRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint FoodUID { get; set; }

    public byte FoodPos { get; set; }

    public bool Preview { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(FoodUID);
        writer.WriteByte(FoodPos);
        writer.WriteBoolean(Preview);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        FoodUID = reader.ReadVarUInt();
        FoodPos = reader.ReadByte();
        Preview = reader.ReadBoolean();
    }
}