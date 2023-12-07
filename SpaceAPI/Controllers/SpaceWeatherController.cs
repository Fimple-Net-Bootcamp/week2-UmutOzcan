using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SpaceAPI.Models;
namespace SpaceAPI.Controllers;

[ApiController]
[Route("/api/v1/planets")]
public class SpaceWeatherController : ControllerBase
{
    private static readonly List<Planet> Planets =
    [
        new Planet
        {
            Id = 1,
            Name = "Mars",
            Weather = new Weather { Condition = "Clear", Temperature = -20.5 },
            Moons =
            [
                new Moon { Id = 1, Name = "Phobos", Weather = new Weather { Condition = "Dusty", Temperature = -40.0 } },
                new Moon { Id = 2, Name = "Deimos", Weather = new Weather { Condition = "Cold", Temperature = -60.0 } }
            ]
        },
        new Planet
        {
            Id = 2,
            Name = "Jupiter",
            Weather = new Weather { Condition = "Stormy", Temperature = -145.0 },
            Moons =
            [
                new Moon { Id = 1, Name = "Europa", Weather = new Weather { Condition = "Icy", Temperature = -100.0 } },
                new Moon { Id = 2, Name = "Io", Weather = new Weather { Condition = "Volcanic", Temperature = 150.0 } }
            ]
        },
        new Planet
        {
            Id = 3,
            Name = "Saturn",
            Weather = new Weather { Condition = "Stormy", Temperature = -145.0 },
            Moons =
            [
                new Moon { Id = 1, Name = "Titan", Weather = new Weather { Condition = "Icy & Dusty", Temperature = -179.2 } },
                new Moon { Id = 2, Name = "Enceladus", Weather = new Weather { Condition = "Icy & Foggy", Temperature = -198.0 } }
            ]
        },
    ];

    // /api/v1/planets
    [HttpGet]
    public IActionResult GetPlanets()
    {
        return Ok(Planets); // 200 OK
    }

    // /api/v1/planets/Mars
    [HttpGet("{planetName}")]
    public IActionResult GetPlanetByName(string planetName)
    {
        var planet = Planets.Find(p => p.Name.ToLower() == planetName.ToLower());

        if (planet == null) return NotFound(); // 404 Not Found

        return Ok(planet); // 200 OK
    }

    // /api/v1/planets/Mars/Phobos
    [HttpGet("{planetName}/{moonName}")]
    public IActionResult GetMoonByPlanet(string planetName, string moonName)
    {
        var planet = Planets.Find(p => p.Name.ToLower() == planetName.ToLower());

        if (planet == null) return NotFound("Planet Not Found "); // 404 Not Found

        var moon = planet.Moons.Find(m => m.Name.ToLower() == moonName.ToLower());

        if (moon == null) return NotFound("Moon Not Found "); // 404 Not Found

        return Ok(moon); // 200 OK
    }

    // /api/v1/planets/?page=1&size=10
    [HttpGet("page,size")]
    public IActionResult GetAllWithPaging([FromQuery] int page = 1, [FromQuery] int size = 10)
    {
        var paginatedPlanets = Planets.Skip((page - 1) * size).Take(size).ToList();
        return Ok(paginatedPlanets); // 200 Ok

    }

    // HTTP POST ile ekledikten sonra GET ile yeni eklenen Gezegeni getirir
    // nameof ile method ismi alýnca adý deðiþse bile orasý da onu takip eder
    // CreatedAtAction ile POST ile olusturulan degeri GET ile gormek istersen adresi verir
    // /api/v1/planets/Earth
    [HttpPost]
    public IActionResult AddPlanet([FromBody] Planet newPlanet)
    {
        Planets.Add(newPlanet);

        return CreatedAtAction(nameof(GetPlanetByName), new { planetName = newPlanet.Name }, newPlanet); // 201 Created
    }

    // HTTP UPDATE ile isim kullanarak Gezegen Gunceller
    [HttpPut("{id}")]
    public IActionResult UpdatePlanet(int id, [FromBody] Planet updatedPlanet)
    {
        var existingPlanet = Planets.Find(p => p.Id == id);

        if (existingPlanet == null) return NotFound(); // 404 Not Found

        existingPlanet.Weather = updatedPlanet.Weather;
        existingPlanet.Moons = updatedPlanet.Moons;

        return Ok(); // 200 Ok
    }

    // HTTP DELETE ile isim kullanarak Gezegen Siler
    [HttpDelete("{planetName}")]
    public IActionResult DeletePlanet(string planetName)
    {
        var planetToRemove = Planets.Find(p => p.Name.ToLower() == planetName.ToLower());

        if (planetToRemove == null) return NotFound(); // 404 Not Found

        Planets.Remove(planetToRemove);

        return NoContent(); // 204 No Content
    }

    // HTTP Patch ile id kullanarak istenilen kismi degistirir
    // Newtonsoft.Json eklenmeli patch icin ve .AddNewtonsoftJson(); Program.cs' e eklenmeli
    [HttpPatch("{id}")]
    public IActionResult PatchPlanet(int id, [FromBody] JsonPatchDocument<Planet> patchDocument)
    {
        var newPlanet = Planets.Find(p => p.Id == id);
        if (newPlanet == null) return NoContent(); // 204 No Content

        patchDocument.ApplyTo(newPlanet);
        return Ok();
    }
}
