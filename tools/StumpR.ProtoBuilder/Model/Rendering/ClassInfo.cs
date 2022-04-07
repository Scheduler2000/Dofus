#pragma warning disable CS8618
namespace StumpR.ProtoBuilder.Model.Rendering;

/// <summary>
///     <see cref="ClassInfo" /> represents a C# class
/// </summary>
public class ClassInfo : EntityInfo
{
    public ClassInfo()
    {
        Properties = new List<PropertyInfo>();
        ParentProperties = new List<PropertyInfo>();
    }

    public List<PropertyInfo> Properties { get; }

    public IList<PropertyInfo> ParentProperties { get; }

    public bool HasParent { get; set; }

    public string Parent { get; set; }
}