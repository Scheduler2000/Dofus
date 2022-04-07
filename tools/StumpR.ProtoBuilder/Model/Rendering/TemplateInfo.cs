#pragma warning disable CS8618
namespace StumpR.ProtoBuilder.Model.Rendering;

/// <summary>
///     <see cref="TemplateInfo" /> represents all the information used to render the templates using scribans.
/// </summary>
public class TemplateInfo
{
    private TemplateInfo()
    {
        GenerationDate = DateTime.Now.ToString("G");
    }

    public TemplateInfo(ClassInfo layout) : this()
    {
        Layout = layout;
    }

    public TemplateInfo(EnumInfo layout) : this()
    {
        Layout = layout;
    }

    public string GenerationDate { get; }

    public object Layout { get; }
}