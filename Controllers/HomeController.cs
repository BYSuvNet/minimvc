using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ILogger _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Hello from the Index action in HomeController!");

        //Vi låtsas att denna lista med highscores kommer från en databas:
        var hsList = new List<HighScore>
        {
            new HighScore { Name = "John", Score = 100 },
            new HighScore { Name = "Doe", Score = 200 }
        };

        ViewData["Message"] = "Hello from ViewData!";
        ViewBag.Blaha = hsList;

        //Här skickar vi in listan till vår vy så att den kan använda den för att visa en lista med highscores:
        return View(hsList);
    }

    //Denna action-metod används för att visa en "Om"-sidan som ligger i /Views/Home/about.cshtml
    public IActionResult About()
    {
        return View();
    }
}
