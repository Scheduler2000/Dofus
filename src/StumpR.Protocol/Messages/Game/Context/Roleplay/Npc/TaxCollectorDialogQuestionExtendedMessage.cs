using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorDialogQuestionExtendedMessage : TaxCollectorDialogQuestionBasicMessage
{
    public new const uint Id = 625;

    public TaxCollectorDialogQuestionExtendedMessage(BasicGuildInformations guildInfo,
        ushort maxPods,
        ushort prospecting,
        ushort wisdom,
        sbyte taxCollectorsCount,
        int taxCollectorAttack,
        ulong kamas,
        ulong experience,
        uint pods,
        ulong itemsValue)
    {
        GuildInfo = guildInfo;
        MaxPods = maxPods;
        Prospecting = prospecting;
        Wisdom = wisdom;
        TaxCollectorsCount = taxCollectorsCount;
        TaxCollectorAttack = taxCollectorAttack;
        Kamas = kamas;
        Experience = experience;
        Pods = pods;
        ItemsValue = itemsValue;
    }

    public TaxCollectorDialogQuestionExtendedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort MaxPods { get; set; }

    public ushort Prospecting { get; set; }

    public ushort Wisdom { get; set; }

    public sbyte TaxCollectorsCount { get; set; }

    public int TaxCollectorAttack { get; set; }

    public ulong Kamas { get; set; }

    public ulong Experience { get; set; }

    public uint Pods { get; set; }

    public ulong ItemsValue { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(MaxPods);
        writer.WriteVarUShort(Prospecting);
        writer.WriteVarUShort(Wisdom);
        writer.WriteSByte(TaxCollectorsCount);
        writer.WriteInt(TaxCollectorAttack);
        writer.WriteVarULong(Kamas);
        writer.WriteVarULong(Experience);
        writer.WriteVarUInt(Pods);
        writer.WriteVarULong(ItemsValue);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MaxPods = reader.ReadVarUShort();
        Prospecting = reader.ReadVarUShort();
        Wisdom = reader.ReadVarUShort();
        TaxCollectorsCount = reader.ReadSByte();
        TaxCollectorAttack = reader.ReadInt();
        Kamas = reader.ReadVarULong();
        Experience = reader.ReadVarULong();
        Pods = reader.ReadVarUInt();
        ItemsValue = reader.ReadVarULong();
    }
}