using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectTransfertListWithQuantityToInvMessage : Message
{
    public const uint Id = 5493;

    public ExchangeObjectTransfertListWithQuantityToInvMessage(IEnumerable<uint> ids, IEnumerable<uint> qtys)
    {
        Ids = ids;
        Qtys = qtys;
    }

    public ExchangeObjectTransfertListWithQuantityToInvMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> Ids { get; set; }

    public IEnumerable<uint> Qtys { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Ids.Count());
        foreach (uint objectToSend in Ids) writer.WriteVarUInt(objectToSend);
        writer.WriteShort((short) Qtys.Count());
        foreach (uint objectToSend in Qtys) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort idsCount = reader.ReadUShort();
        var ids_ = new uint[idsCount];
        for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) ids_[idsIndex] = reader.ReadVarUInt();
        Ids = ids_;
        ushort qtysCount = reader.ReadUShort();
        var qtys_ = new uint[qtysCount];
        for (var qtysIndex = 0; qtysIndex < qtysCount; qtysIndex++) qtys_[qtysIndex] = reader.ReadVarUInt();
        Qtys = qtys_;
    }
}