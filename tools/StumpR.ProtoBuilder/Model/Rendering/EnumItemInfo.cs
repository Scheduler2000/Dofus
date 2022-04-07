namespace StumpR.ProtoBuilder.Model.Rendering;

public class EnumItemInfo
{
    public EnumItemInfo(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; }

    public string Value { get; }
}