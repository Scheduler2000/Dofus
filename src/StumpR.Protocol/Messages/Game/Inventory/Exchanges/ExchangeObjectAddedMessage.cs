﻿using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectAddedMessage : ExchangeObjectMessage
{
    public new const uint Id = 2329;

    public ExchangeObjectAddedMessage(bool remote, ObjectItem @object)
    {
        Remote = remote;
        this.@object = @object;
    }

    public ExchangeObjectAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItem @object { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        @object.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        @object = new ObjectItem();
        @object.Deserialize(reader);
    }
}