namespace StumpR.ProtoBuilder.Model.Rendering;

public class EnumInfo : EntityInfo
{
    public EnumInfo()
    {
        Elements = new List<EnumItemInfo>();
    }

    public IList<EnumItemInfo> Elements { get; }
}