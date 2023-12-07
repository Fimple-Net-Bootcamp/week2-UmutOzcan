namespace SpaceAPI.Models;

public class Planet // Gezegen s�n�f�
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required Weather Weather { get; set; }
    public required List<Moon> Moons { get; set; }
}
