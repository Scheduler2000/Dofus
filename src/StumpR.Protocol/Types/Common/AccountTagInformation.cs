using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AccountTagInformation
{
    public const short Id = 7636;

    public AccountTagInformation(string nickname, string tagNumber)
    {
        Nickname = nickname;
        TagNumber = tagNumber;
    }

    public AccountTagInformation()
    {
    }

    public virtual short TypeId => Id;

    public string Nickname { get; set; }

    public string TagNumber { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(Nickname);
        writer.WriteUTF(TagNumber);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Nickname = reader.ReadUTF();
        TagNumber = reader.ReadUTF();
    }
}