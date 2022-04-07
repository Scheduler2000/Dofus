namespace StumpR.GUI.Sniffer.Models;

public class Device
{
    public int Id { get; }

    public string Name { get; }

    public string Description { get; }

    public Device(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

}