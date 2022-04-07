#pragma warning disable CS8618
namespace StumpR.Protocol.Datacenter;

public class TransformData
{
    public string OverrideClip { get; set; }

    public string OriginalClip { get; set; }

    public Point Point { get; set; }

    public int ScaleX { get; set; }

    public int ScaleY { get; set; }

    public int Rotation { get; set; }
}