using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Продукция")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Trademark")]
        [DisplayName("Торговая марка")]
        public int TrademarkId { get; set; }
        [DisplayName("Торговая марка")]
        public Trademark? Trademark { get; set; }

        [Required]
        [ForeignKey("ProductType")]
        [DisplayName("Тип продукции")]
        public int ProductTypeId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        [DisplayName("Тип продукции")]
        public ProductType? ProductType { get; set; }

        [Required]
        [ForeignKey("Flavor")]
        [DisplayName("Разновидность")]
        public int FlavorId { get; set; }
        [DisplayName("Разновидность")]
        public Flavor? Flavor { get; set; }

        [Required]
        [ForeignKey("Weight")]
        [DisplayName("Фасовка")]
        public int WeightId { get; set; }
        [DisplayName("Фасовка")]
        public Weight? Weight { get; set; }

        [NotMapped]
        [DisplayName("Название")]
        public string Name => $"{Trademark?.Name} - {ProductType?.Name} - {Flavor?.Name} - {Weight?.Grams}";

        [NotMapped]
        [DisplayName("Продукция")]
        public string? Index { get; set; } = null;
    }
}
