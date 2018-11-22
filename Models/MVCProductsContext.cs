using Microsoft.EntityFrameworkCore;  
namespace blog.Models
{
    public class MVCProductsContext : DbContext 
    {
        public MVCProductsContext (DbContextOptions<MVCProductsContext> options)  
            : base(options)  
        {  
        }  
        public DbSet<blog.Models.FileModel> Files { get; set; }
        public DbSet<blog.Models.ProductClass> Product { get; set; }  
    }  
}