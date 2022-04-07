﻿using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorAttackedResultMessage : Message
{
    public const uint Id = 7270;

    public TaxCollectorAttackedResultMessage(bool deadOrAlive, TaxCollectorBasicInformations basicInfos, BasicGuildInformations guild)
    {
        DeadOrAlive = deadOrAlive;
        BasicInfos = basicInfos;
        Guild = guild;
    }

    public TaxCollectorAttackedResultMessage()
    {
    }

    public override uint MessageId => Id;

    public bool DeadOrAlive { get; set; }

    public TaxCollectorBasicInformations BasicInfos { get; set; }

    public BasicGuildInformations Guild { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(DeadOrAlive);
        BasicInfos.Serialize(writer);
        Guild.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        DeadOrAlive = reader.ReadBoolean();
        BasicInfos = new TaxCollectorBasicInformations();
        BasicInfos.Deserialize(reader);
        Guild = new BasicGuildInformations();
        Guild.Deserialize(reader);
    }
}