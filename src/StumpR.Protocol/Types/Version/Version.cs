using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class Version
{
    public const short Id = 3781;

    public Version(sbyte major, sbyte minor, sbyte code, int build, sbyte buildType)
    {
        Major = major;
        Minor = minor;
        Code = code;
        Build = build;
        BuildType = buildType;
    }

    public Version()
    {
    }

    public virtual short TypeId => Id;

    public sbyte Major { get; set; }

    public sbyte Minor { get; set; }

    public sbyte Code { get; set; }

    public int Build { get; set; }

    public sbyte BuildType { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Major);
        writer.WriteSByte(Minor);
        writer.WriteSByte(Code);
        writer.WriteInt(Build);
        writer.WriteSByte(BuildType);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Major = reader.ReadSByte();
        Minor = reader.ReadSByte();
        Code = reader.ReadSByte();
        Build = reader.ReadInt();
        BuildType = reader.ReadSByte();
    }
}