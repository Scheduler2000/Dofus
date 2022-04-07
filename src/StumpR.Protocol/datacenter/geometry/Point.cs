namespace StumpR.Protocol.Datacenter;

public class Point
{

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point()
    {
    }

    public int X { get; set; }

    public int Y { get; set; }
}