using System.ComponentModel.DataAnnotations;
namespace Biblioteca_MVC.Models
{
    public class BookLoansModel
    {
        public DateTime DataImprumut { get; set; }
        public DateTime DataRetur { get; set; }
        public Guid IDMembru { get; set; }
        [Key]
        public Guid IDImprumut { get; set; }
        public Guid IDCarte { get; set; }
        
    }
}
