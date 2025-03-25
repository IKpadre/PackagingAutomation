using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Производственная линия")]
    public class ProductionLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Упаковочные автоматы")]
        public List<PackagingMachine> Machines { get; set; } = new();

        [NotMapped]
        [DisplayName("Производственные линии")]
        public string? Index { get; set; } = null;
    }
}
