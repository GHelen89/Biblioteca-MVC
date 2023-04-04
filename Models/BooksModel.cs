using System.ComponentModel.DataAnnotations;
namespace Biblioteca_MVC.Models
{
    public class BooksModel
    {
        [Key]
        public Guid IDCarte { get; set; }
        public string NumeCarte{ get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public DateTime AnAparitie { get; set; }

        public Boolean Imprumutata { get; set; }
      //  public DateTime? DataImprumut { get; set; }
       // public DateTime? DataRetur { get; set; }
        //public Guid? IDMembru { get; set; }
    }
}
