﻿using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectTransfertListFromInvMessage : Message
{
    public const uint Id = 3871;

    public ExchangeObjectTransfertListFromInvMessage(IEnumerable<uint> ids)
    {
        Ids = ids;
    }

    public ExchangeObjectTransfertListFromInvMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> Ids { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Ids.Count());
        foreach (uint objectToSend in Ids) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort idsCount = reader.ReadUShort();
        var ids_ = new uint[idsCount];
        for (var idsIndex = 0; idsIndex < idsCount; idsIndex++) ids_[idsIndex] = reader.ReadVarUInt();
        Ids = ids_;
    }
}