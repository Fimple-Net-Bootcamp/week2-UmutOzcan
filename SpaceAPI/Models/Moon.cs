namespace SpaceAPI.Models;

public class Moon // Uydu Sınıfı
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required Weather Weather { get; set; }
}
