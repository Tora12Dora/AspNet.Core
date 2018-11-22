using Microsoft.AspNetCore.Http;
namespace blog.Models
{
    public class ProductsViewModel
    {
    public IFormFile photo { get; set; }
    public string name { get; set; }

    public int money {get;set;}
    public string description {get; set;}
    
}
}
