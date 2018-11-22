using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace blog.Models
{
    public class ProductClass
    {
        [Required (ErrorMessage = "Поле не может быть пустым")]
        [Display(Name = "id")]
          public int id {get; set;}
        
         public byte[] photo {get;set;}
        // public IFormFile Avatar { get; set; }
        [Display(Name = "name")]
        
        [Required (ErrorMessage = "Поле должно быть установлено")]
        [StringLength(15, ErrorMessage = "Длина строки должна быть от 2 до 15 символов")]        
        public string name  {get; set;}


        [Display(Name = "Price")]
        //[Required (ErrorMessage = "Поле не пустое")]
        [Range(1, 100000, ErrorMessage = "Не может превышать 100000")]
        [DataType(DataType.Currency)]
        public int money {get; set;}

        public string description {get; set;}
        //public HttpPostedFileBase File { get; set; }
        
    
    public ProductClass(){}
    public ProductClass(int id, string name, int money)
    {
        this.id = id;
        this.name = name;
        this.money = money;
    }
    }
}