using StumpR.ProtoBuilder.Cache;
using StumpR.ProtoBuilder.Helpers;

namespace StumpR.ProtoBuilder.Model.Rendering;

/// <summary>
///     <see cref="PropertyInfo" /> represents a C# property
/// </summary>
/// <param name="Name">Name of the property</param>
/// <param name="Type">Type of the property</param>
public class PropertyInfo
{
    public PropertyInfo(string name, string type) : this(name, type, string.Empty)
    { }

    public PropertyInfo(string name, string type, string value, bool isConst = false)
    {
        Name = name;
        Type = type;
        Value = value;
        IsConst = isConst;
    }

    public string Name { get; }

    public string LocalVariableName
    {
        get
        {
            var decapitalize = Name.Decapitalize();
            return KeywordCache.Instance.EnsureWord(decapitalize) ? decapitalize : $"@{decapitalize}";
        }
    }

    public string Type { get; }

    public string Value { get; }

    public bool IsConst { get; }

    public override bool Equals(object obj)
    {
        return obj is PropertyInfo propertyInfo &&
               Name == propertyInfo.Name &&
               Type == propertyInfo.Type;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Type, Value, IsConst);
    }
}