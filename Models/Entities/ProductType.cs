using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Тип продукции")]
    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Продукция")]
        public List<Product> Products { get; set; } = new();

        [DisplayName("Разновидности")]
        public List<Flavor> Flavors { get; set; } = new();

        [NotMapped]
        [DisplayName("Типы продукции")]
        public string? Index { get; set; } = null;
    }
}
