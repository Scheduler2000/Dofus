using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
{
    public new const short Id = 3425;

    public GameRolePlayMerchantInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        string name,
        sbyte sellType,
        IEnumerable<HumanOption> options)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Name = name;
        SellType = sellType;
        Options = options;
    }

    public GameRolePlayMerchantInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte SellType { get; set; }

    public IEnumerable<HumanOption> Options { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(SellType);
        writer.WriteShort((short) Options.Count());

        foreach (HumanOption objectToSend in Options)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SellType = reader.ReadSByte();
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