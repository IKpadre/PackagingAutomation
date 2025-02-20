using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Заказчик")]
    public class Distributor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Заказы")]
        public List<Order> Orders { get; set; } = new();

        [NotMapped]
        [DisplayName("Заказчики")]
        public string? Index { get; set; } = null;
    }
}
