using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
{
    public new const short Id = 345;

    public GameRolePlayHumanoidInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        string name,
        HumanInformations humanoidInfo,
        int accountId)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        Name = name;
        HumanoidInfo = humanoidInfo;
        AccountId = accountId;
    }

    public GameRolePlayHumanoidInformations()
    {
    }

    public override short TypeId => Id;

    public HumanInformations HumanoidInfo { get; set; }

    public int AccountId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(HumanoidInfo.TypeId);
        HumanoidInfo.Serialize(writer);
        writer.WriteInt(AccountId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        HumanoidInfo = ProtocolTypeManager.GetInstance<HumanInformations>(reader.ReadShort());
        HumanoidInfo.Deserialize(reader);
        AccountId = reader.ReadInt();
    }
}