using AnimalAdpApplication.Services;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly AnimalService _animalService;

    public HomeController(AnimalService animalService)
    {
        _animalService = animalService;
    }

    public async Task<IActionResult> Index()
    {
        var animals = await _animalService.GetAllAnimalsAsync();
        return View(animals);
    }
}
