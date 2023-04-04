using System.ComponentModel.DataAnnotations;
namespace Biblioteca_MVC.Models
{
    public class MembersModel
    {
        [Key]
        public Guid IDMembru { get; set; }
        public string NumeMembru { get; set; }
    }
}
