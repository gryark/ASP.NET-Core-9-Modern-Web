using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MySecondWebRazor.Pages;

public class IndexModel : PageModel

{
    public string Message { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new List<Product>();
    public string Color { get; set; } = string.Empty;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Products = GenerateProduct(10);
        Message = "I'm using the Razor Syntax.";
    }

    private List<Product> GenerateProduct(int quantity)
    {
        var random = new Random();
        var products = Enumerable.Range(1,
          quantity).Select(i => new Product
          {
              Id = i,
              Name = $"Product {i}",
              Price = (decimal)(random.NextDouble() * 100.0)
          });
        return products.ToList();
    }

    public void OnGet()
    {

    }
    public void OnPost(int quantity)
    {
        Products = GenerateProduct(quantity);
    }
    public void OnGetDefineColor(int id)
    {
        Color = id == 1 ? "#FF0000" : "green";
    }
}
