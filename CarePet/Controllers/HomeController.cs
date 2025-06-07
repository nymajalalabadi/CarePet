using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarePet.Models;

namespace CarePet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Sample data for pets (since we're not using database)
        var featuredPets = GetSamplePets().Take(6).ToList();
        return View(featuredPets);
    }

    public IActionResult Services()
    {
        var services = GetSampleServices();
        return View(services);
    }

    public IActionResult Pets()
    {
        var pets = GetSamplePets();
        return View(pets);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View(new Contact());
    }

    [HttpPost]
    public IActionResult Contact(Contact contact)
    {
        if (ModelState.IsValid)
        {
            // Here you would normally save to database
            // For demo purposes, we'll just show success message
            TempData["Success"] = "Thank you for your message! We'll get back to you soon.";
            return RedirectToAction("Contact");
        }
        
        return View(contact);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // Sample data methods (replacing database)
    private List<Pet> GetSamplePets()
    {
        return new List<Pet>
        {
            new Pet { Id = 1, Name = "Buddy", Type = "Dog", Breed = "Golden Retriever", Age = 3, Color = "Golden", Gender = "Male", ImageUrl = "https://images.unsplash.com/photo-1552053831-71594a27632d?w=500", Description = "Friendly and energetic dog, loves playing fetch!", IsAvailable = true },
            new Pet { Id = 2, Name = "Luna", Type = "Cat", Breed = "Persian", Age = 2, Color = "White", Gender = "Female", ImageUrl = "https://images.unsplash.com/photo-1574158622682-e40e69881006?w=500", Description = "Calm and gentle cat, perfect for families.", IsAvailable = true },
            new Pet { Id = 3, Name = "Charlie", Type = "Dog", Breed = "Labrador", Age = 1, Color = "Brown", Gender = "Male", ImageUrl = "https://images.unsplash.com/photo-1587300003388-59208cc962cb?w=500", Description = "Young and playful puppy, great with kids.", IsAvailable = true },
            new Pet { Id = 4, Name = "Mia", Type = "Cat", Breed = "Siamese", Age = 4, Color = "Cream", Gender = "Female", ImageUrl = "https://images.unsplash.com/photo-1513245543132-31f507417b26?w=500", Description = "Intelligent and vocal cat, very social.", IsAvailable = true },
            new Pet { Id = 5, Name = "Max", Type = "Dog", Breed = "German Shepherd", Age = 5, Color = "Black & Tan", Gender = "Male", ImageUrl = "https://images.unsplash.com/photo-1589941013453-ec89f33b5e95?w=500", Description = "Loyal and protective, well-trained.", IsAvailable = true },
            new Pet { Id = 6, Name = "Bella", Type = "Cat", Breed = "Maine Coon", Age = 3, Color = "Orange", Gender = "Female", ImageUrl = "https://images.unsplash.com/photo-1592194996308-7b43878e84a6?w=500", Description = "Large and gentle cat, very affectionate.", IsAvailable = true },
        };
    }

    private List<CareService> GetSampleServices()
    {
        return new List<CareService>
        {
            new CareService { Id = 1, Title = "Pet Grooming", Description = "Professional grooming services to keep your pet clean and healthy.", Price = 45.00m, Duration = "1-2 hours", IconName = "scissors", Category = "Grooming", IsPopular = true },
            new CareService { Id = 2, Title = "Veterinary Care", Description = "Comprehensive health checkups and medical care for your pets.", Price = 75.00m, Duration = "30-60 minutes", IconName = "stethoscope", Category = "Medical", IsPopular = true },
            new CareService { Id = 3, Title = "Pet Training", Description = "Professional training sessions to improve your pet's behavior.", Price = 60.00m, Duration = "1 hour", IconName = "target", Category = "Training", IsPopular = false },
            new CareService { Id = 4, Title = "Pet Sitting", Description = "Reliable pet sitting services when you're away from home.", Price = 25.00m, Duration = "Per day", IconName = "home", Category = "Care", IsPopular = true },
            new CareService { Id = 5, Title = "Pet Walking", Description = "Daily exercise and walks to keep your pet active and healthy.", Price = 20.00m, Duration = "30 minutes", IconName = "footprints", Category = "Exercise", IsPopular = false },
            new CareService { Id = 6, Title = "Pet Boarding", Description = "Safe and comfortable boarding for extended periods.", Price = 40.00m, Duration = "Per night", IconName = "bed", Category = "Boarding", IsPopular = true },
        };
    }
}
