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

    public IActionResult PetDetails(int id)
    {
        var pet = GetSamplePets().FirstOrDefault(p => p.Id == id);
        if (pet == null)
        {
            return NotFound();
        }
        return View(pet);
    }

    public IActionResult Adopt(int petId)
    {
        var pet = GetSamplePets().FirstOrDefault(p => p.Id == petId);
        if (pet == null)
        {
            return NotFound();
        }

        var application = new AdoptionApplication
        {
            PetId = petId
        };

        ViewBag.Pet = pet;
        return View(application);
    }

    [HttpPost]
    public IActionResult Adopt(AdoptionApplication application)
    {
        var pet = GetSamplePets().FirstOrDefault(p => p.Id == application.PetId);
        if (pet == null)
        {
            return NotFound();
        }

        ViewBag.Pet = pet;

        if (ModelState.IsValid)
        {
            // Here you would normally save to database
            // For demo purposes, we'll just show success message
            TempData["Success"] = $"Thank you for your adoption application for {pet.Name}! We'll review your application and contact you within 2-3 business days.";
            return RedirectToAction("AdoptionSuccess", new { petId = application.PetId });
        }

        return View(application);
    }

    public IActionResult AdoptionSuccess(int petId)
    {
        var pet = GetSamplePets().FirstOrDefault(p => p.Id == petId);
        if (pet == null)
        {
            return NotFound();
        }
        return View(pet);
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

    public IActionResult Terms()
    {
        return View();
    }

    public IActionResult Blog()
    {
        var blogPosts = GetSampleBlogPosts();
        return View(blogPosts);
    }

    public IActionResult BlogPost(int id)
    {
        var post = GetSampleBlogPosts().FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return NotFound();
        }
        
        // Add related articles (excluding current post)
        var allPosts = GetSampleBlogPosts();
        post.RelatedArticles = allPosts
            .Where(p => p.Id != id)
            .Take(3)
            .ToList();
        
        return View(post);
    }

    public IActionResult FAQ()
    {
        var faqs = GetSampleFAQs();
        return View(faqs);
    }

    public IActionResult Testimonials()
    {
        var testimonials = GetSampleTestimonials();
        return View(testimonials);
    }

    public IActionResult AdoptionProcess()
    {
        return View();
    }


    public IActionResult Volunteer()
    {
        return View(new VolunteerApplication());
    }

    [HttpPost]
    public IActionResult Volunteer(VolunteerApplication application)
    {
        if (ModelState.IsValid)
        {
            TempData["Success"] = "Thank you for your interest in volunteering! We'll contact you soon.";
            return RedirectToAction("Volunteer");
        }
        return View(application);
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
            new Pet { Id = 1, Name = "Buddy", Type = "Dog", Breed = "Golden Retriever", Age = 3, Color = "Golden", Gender = "Male", ImageUrl = "/image/pets/dog7.png", Description = "Friendly and energetic dog, loves playing fetch! He's great with kids and other pets. Buddy enjoys long walks, playing in the yard, and cuddling on the couch. He's house-trained and knows basic commands like sit, stay, and come.", IsAvailable = true },
            new Pet { Id = 2, Name = "Luna", Type = "Cat", Breed = "Persian", Age = 2, Color = "White", Gender = "Female", ImageUrl = "/image/pets/dog8.png", Description = "Calm and gentle cat, perfect for families. Luna loves to be petted and will purr contentedly in your lap. She's very clean, uses her litter box consistently, and gets along well with children. She enjoys playing with feather toys and napping in sunny spots.", IsAvailable = true },
            new Pet { Id = 3, Name = "Charlie", Type = "Dog", Breed = "Labrador", Age = 1, Color = "Brown", Gender = "Male", ImageUrl = "/image/pets/dog3.png", Description = "Young and playful puppy, great with kids. Charlie is full of energy and loves to learn new tricks. He's very social and enjoys meeting new people and dogs. Currently learning house training and basic obedience commands.", IsAvailable = true },
            new Pet { Id = 4, Name = "Mia", Type = "Cat", Breed = "Siamese", Age = 4, Color = "Cream", Gender = "Female", ImageUrl = "/image/pets/dog4.png", Description = "Intelligent and vocal cat, very social. Mia loves to 'talk' to her humans and will follow you around the house. She's very affectionate and enjoys interactive play. She would do best as an only cat or with one other calm cat.", IsAvailable = true },
            new Pet { Id = 5, Name = "Max", Type = "Dog", Breed = "German Shepherd", Age = 5, Color = "Black & Tan", Gender = "Male", ImageUrl = "/image/pets/dog6.png", Description = "Loyal and protective, well-trained. Max is a mature dog who would make an excellent companion for an active family. He knows many commands, walks well on a leash, and is very protective of his family. He would do best with older children.", IsAvailable = true },
            new Pet { Id = 6, Name = "Bella", Type = "Cat", Breed = "Maine Coon", Age = 3, Color = "Orange", Gender = "Female", ImageUrl = "/image/pets/dog5.png", Description = "Large and gentle cat, very affectionate. Bella is a sweet, laid-back cat who loves attention and gentle petting. She gets along well with other cats and would make a wonderful addition to any family. She enjoys playing with toys and watching birds from the window.", IsAvailable = true },
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

    private List<BlogPost> GetSampleBlogPosts()
    {
        return new List<BlogPost>
        {
            new BlogPost { 
                Id = 1, 
                Title = "How to Choose the Right Pet for Your Family", 
                Content = "Choosing a pet is a big decision that affects your entire family. Consider factors like living space, time commitment, allergies, and lifestyle when making this important choice. Different pets have different needs, and understanding these requirements is crucial for a successful adoption. Dogs require daily exercise and social interaction, while cats are more independent but still need attention and care. Consider your work schedule, family dynamics, and long-term commitment before making this important decision.", 
                Summary = "A comprehensive guide to selecting the perfect pet that matches your family's lifestyle, living situation, and long-term commitment capabilities.",
                Author = "Dr. Sarah Johnson", 
                Date = DateTime.Now.AddDays(-7), 
                ImageUrl = "/image/pets/dog1.png", 
                Category = "Pet Care",
                ReadTime = 8,
                Views = 1245,
                Tags = new List<string> { "pet selection", "family pets", "adoption guide" }
            },
            new BlogPost { 
                Id = 2, 
                Title = "Essential Pet Care Tips for New Owners", 
                Content = "Being a new pet owner can be overwhelming. Here are essential tips for feeding, grooming, training, and keeping your new companion healthy and happy. Establishing routines is crucial for your pet's wellbeing. Create feeding schedules, exercise routines, and regular vet checkups. Proper nutrition, regular grooming, and consistent training will help your pet adjust to their new home and develop into a well-behaved family member.", 
                Summary = "Complete beginner's guide covering feeding, grooming, training, and health care essentials for new pet owners.",
                Author = "Mark Wilson", 
                Date = DateTime.Now.AddDays(-14), 
                ImageUrl = "/image/pets/dog2.png", 
                Category = "Training",
                ReadTime = 6,
                Views = 892,
                Tags = new List<string> { "new owners", "pet care basics", "training tips" }
            },
            new BlogPost { 
                Id = 3, 
                Title = "The Benefits of Pet Adoption", 
                Content = "Adopting a pet from a shelter not only saves a life but also brings numerous benefits to your family. Learn about the advantages of choosing adoption over buying. Shelter pets are often already house-trained and socialized. Additionally, adoption fees typically include vaccinations, spaying/neutering, and microchipping, providing excellent value. By adopting, you're also supporting local animal welfare efforts and helping reduce pet overpopulation.", 
                Summary = "Discover the many advantages of pet adoption for both families and animals, including cost savings and social benefits.",
                Author = "Emily Chen", 
                Date = DateTime.Now.AddDays(-21), 
                ImageUrl = "/image/pets/dog3.png", 
                Category = "Adoption",
                ReadTime = 5,
                Views = 567,
                Tags = new List<string> { "adoption", "shelter pets", "animal welfare" }
            },
            new BlogPost { 
                Id = 4, 
                Title = "Understanding Pet Behavior and Body Language", 
                Content = "Learning to read your pet's body language is crucial for building a strong bond. Discover what your pet is trying to communicate through their actions and expressions. Dogs wag their tails when happy but also when nervous. Cats purr when content but may also purr when stressed. Understanding these subtle differences helps you respond appropriately to your pet's needs and strengthens your relationship.", 
                Summary = "Learn to interpret your pet's body language and behavioral cues to strengthen your bond and improve communication.",
                Author = "Dr. Michael Brown", 
                Date = DateTime.Now.AddDays(-28), 
                ImageUrl = "/image/pets/dog4.png", 
                Category = "Behavior",
                ReadTime = 7,
                Views = 723,
                Tags = new List<string> { "pet behavior", "body language", "communication" }
            },
            new BlogPost { 
                Id = 5, 
                Title = "Pet Nutrition: Feeding Your Companion Right", 
                Content = "Proper nutrition is fundamental to your pet's health and longevity. Understanding nutritional needs, reading food labels, and establishing healthy feeding habits will keep your pet in optimal condition. Different life stages require different nutritional approaches, and certain health conditions may require special diets.", 
                Summary = "Essential guide to pet nutrition covering food selection, feeding schedules, and nutritional requirements for optimal health.",
                Author = "Dr. Jennifer Martinez", 
                Date = DateTime.Now.AddDays(-35), 
                ImageUrl =  "/image/pets/dog5.png", 
                Category = "Health",
                ReadTime = 9,
                Views = 934,
                Tags = new List<string> { "nutrition", "feeding", "pet health" }
            },
            new BlogPost { 
                Id = 6, 
                Title = "Creating a Safe Home Environment for Pets", 
                Content = "Pet-proofing your home is essential for keeping your companion safe. Learn about common household hazards, toxic plants, and how to create secure spaces for your pets. Remove dangerous items, secure cabinets with chemicals, and ensure your pet has a comfortable, safe space to rest and play.", 
                Summary = "Comprehensive guide to pet-proofing your home and creating a safe, comfortable environment for your furry friends.",
                Author = "Lisa Thompson", 
                Date = DateTime.Now.AddDays(-42), 
                ImageUrl = "/image/pets/dog6.png", 
                Category = "Safety",
                ReadTime = 6,
                Views = 445,
                Tags = new List<string> { "pet safety", "home preparation", "pet proofing" }
            }
        };
    }

    private List<GalleryPhoto> GetSampleGalleryPhotos()
    {
        return new List<GalleryPhoto>
        {
            new GalleryPhoto { Id = 1, Title = "Happy Adoption Day", ImageUrl = "https://images.unsplash.com/photo-1601758228041-f3b2795255f1?w=500", Description = "Luna's adoption day celebration", Category = "Adoptions" },
            new GalleryPhoto { Id = 2, Title = "Playtime Fun", ImageUrl = "https://images.unsplash.com/photo-1587300003388-59208cc962cb?w=500", Description = "Charlie playing in the yard", Category = "Activities" },
            new GalleryPhoto { Id = 3, Title = "Training Session", ImageUrl = "https://images.unsplash.com/photo-1552053831-71594a27632d?w=500", Description = "Buddy learning new tricks", Category = "Training" },
            new GalleryPhoto { Id = 4, Title = "Grooming Day", ImageUrl = "https://images.unsplash.com/photo-1574158622682-e40e69881006?w=500", Description = "Mia getting pampered", Category = "Grooming" },
            new GalleryPhoto { Id = 5, Title = "Rescue Success", ImageUrl = "https://images.unsplash.com/photo-1589941013453-ec89f33b5e95?w=500", Description = "Max's rescue story", Category = "Rescues" },
            new GalleryPhoto { Id = 6, Title = "Cuddle Time", ImageUrl = "https://images.unsplash.com/photo-1592194996308-7b43878e84a6?w=500", Description = "Bella enjoying affection", Category = "Daily Life" },
        };
    }

    private List<FAQ> GetSampleFAQs()
    {
        return new List<FAQ>
        {
            new FAQ { Id = 1, Question = "What is the adoption process?", Answer = "Our adoption process includes an application, home visit, meet & greet with the pet, and a trial period to ensure it's a good match.", Category = "Adoption" },
            new FAQ { Id = 2, Question = "What are the adoption fees?", Answer = "Adoption fees vary by animal: Dogs $150-300, Cats $100-200. Fees include spay/neuter, vaccinations, and microchipping.", Category = "Fees" },
            new FAQ { Id = 3, Question = "Can I return a pet if it doesn't work out?", Answer = "Yes, we have a 30-day return policy. We want to ensure the best match for both you and the pet.", Category = "Policy" },
            new FAQ { Id = 4, Question = "Do you offer training services?", Answer = "Yes, we offer basic obedience training, behavioral consultation, and specialized training programs.", Category = "Services" },
            new FAQ { Id = 5, Question = "What should I bring when adopting?", Answer = "Bring a valid ID, proof of residence, and if renting, permission from your landlord. We'll provide a starter kit.", Category = "Requirements" },
        };
    }

    private List<Testimonial> GetSampleTestimonials()
    {
        return new List<Testimonial>
        {
            new Testimonial { Id = 1, Name = "Jennifer Smith", Content = "CarePet helped us find the perfect companion. Luna has brought so much joy to our family!", Rating = 5, Date = DateTime.Now.AddDays(-30), ImageUrl = "https://images.unsplash.com/photo-1494790108755-2616b612b77c?w=100" },
            new Testimonial { Id = 2, Name = "Robert Johnson", Content = "Professional and caring staff. The adoption process was smooth and they provided excellent support.", Rating = 5, Date = DateTime.Now.AddDays(-45), ImageUrl = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=100" },
            new Testimonial { Id = 3, Name = "Maria Garcia", Content = "Adopted Max two years ago. Best decision ever! The team at CarePet is amazing.", Rating = 5, Date = DateTime.Now.AddDays(-60), ImageUrl = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=100" },
            new Testimonial { Id = 4, Name = "David Wilson", Content = "Their veterinary services are top-notch. My pets receive excellent care here.", Rating = 5, Date = DateTime.Now.AddDays(-75), ImageUrl = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=100" },
        };
    }
}
