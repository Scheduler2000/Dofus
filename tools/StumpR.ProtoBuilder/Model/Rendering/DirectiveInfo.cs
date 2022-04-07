namespace StumpR.ProtoBuilder.Model.Rendering;

/// <summary>
///     <see cref="DirectiveInfo" /> represents a namespace import with the using statement.
/// </summary>
public class DirectiveInfo
{
    public DirectiveInfo(string ns)
    {
        Namespace = ns;
    }

    public string Namespace { get; }
}