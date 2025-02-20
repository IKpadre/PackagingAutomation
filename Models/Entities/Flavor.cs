using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Разновидность")]
    public class Flavor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [ForeignKey("ProductType")]
        [DisplayName("Тип продукции")]
        public int ProductTypeId { get; set; }
        [DisplayName("Тип продукции")]
        public ProductType? ProductType { get; set; }

        [DisplayName("Продукция")]
        public List<Product> Products { get; set; } = new();

        [NotMapped]
        [DisplayName("Разновидности")]
        public string? Index { get; set; } = null;
    }
}
