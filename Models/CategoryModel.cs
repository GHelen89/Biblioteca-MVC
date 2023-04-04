using System.ComponentModel.DataAnnotations;
namespace Biblioteca_MVC.Models
{
    public class CategoryModel
    {
        [Key]
        public Guid IDCategorie { get; set; }
        public string NumeCategorie { get; set; }
        public string Descriere { get; set; }
    }
}
