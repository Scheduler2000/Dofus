using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanInformations
{
    public const short Id = 7547;

    public HumanInformations(ActorRestrictionsInformations restrictions, bool sex, IEnumerable<HumanOption> options)
    {
        Restrictions = restrictions;
        Sex = sex;
        Options = options;
    }

    public HumanInformations()
    {
    }

    public virtual short TypeId => Id;

    public ActorRestrictionsInformations Restrictions { get; set; }

    public bool Sex { get; set; }

    public IEnumerable<HumanOption> Options { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        Restrictions.Serialize(writer);
        writer.WriteBoolean(Sex);
        writer.WriteShort((short) Options.Count());

        foreach (HumanOption objectToSend in Options)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Restrictions = new ActorRestrictionsInformations();
        Restrictions.Deserialize(reader);
        Sex = reader.ReadBoolean();
        ushort optionsCount = reader.ReadUShort();
        var options_ = new HumanOption[optionsCount];

        for (var optionsIndex = 0; optionsIndex < optionsCount; optionsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<HumanOption>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            options_[optionsIndex] = objectToAdd;
        }
        Options = options_;
    }
}