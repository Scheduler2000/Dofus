#pragma warning disable CS8618
namespace StumpR.ProtoBuilder.Model.Rendering;

public abstract class EntityInfo
{
    protected EntityInfo()
    {
        Directives = new List<DirectiveInfo>();
    }

    public string Name { get; set; }

    public string Namespace { get; set; }

    public IList<DirectiveInfo> Directives { get; }
}