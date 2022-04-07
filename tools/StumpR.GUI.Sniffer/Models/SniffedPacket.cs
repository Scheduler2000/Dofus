namespace StumpR.GUI.Sniffer.Models;

public class SniffedPacket
{
    public string Time { get; }

    public string Origin { get; }

    public int Id { get; }

    public string Name { get; }

    public string JsonData { get; }

    public string RawHexData { get; }

    public SniffedPacket(string time, string origin, int id, string name, string jsonData, string rawHexData)
    {
        Time = time;
        Origin = origin;
        Id = id;
        Name = name;
        JsonData = jsonData;
        RawHexData = rawHexData;
    }
}