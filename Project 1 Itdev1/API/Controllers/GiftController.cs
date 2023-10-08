using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Good Day of gifts", "Alright gift day", "Chilly gift day", "Not a good gift day", "Terrible gift day", "Fantastic gift day"
    };

    private readonly ILogger<GiftController> _logger;

    public GiftController(ILogger<GiftController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMysteryBox")]
    public IEnumerable<GiftController> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new GiftController
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Prize = GenerateRandPrize(), 
            AmountOfPrize = random.Next(1, 11), 
            Summary = Summaries[random.Next(Summaries.Length)]
        })
        .ToArray();
    }
      private string GenerateRandPrize()
        {
            string[] nextPrize = new[]
            {
                "Cash", "Electronics", "Gift Card", "Vacation Package", "Jewelry", "Kitchen Appliances", "Books", "Toys", "Video Games", "Under Garments"
            };
            Random random = new Random();
            return nextPrizes[random.Next(nextPrize.Length)];
        }
}
