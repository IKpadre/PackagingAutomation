using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Заказ")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Distributor")]
        [DisplayName("Заказчик")]
        public int DistributorId { get; set; }
        [DisplayName("Заказчик")]
        public Distributor? Distributor { get; set; }

        [Required]
        [ForeignKey("Product")]
        [DisplayName("Продукция")]
        public int ProductId { get; set; }
        [DisplayName("Продукция")]
        public Product? Product { get; set; }

        [Required]
        [DisplayName("Количество")]
        public uint Quantity { get; set; }

        [Required]
        [DisplayName("Дата выпуска")]
        public DateTime Deadline { get; set; }

        [DisplayName("Приоритет")]
        public uint Priority { get; set; } = 0;

        [NotMapped]
        [DisplayName("Заказы")]
        public string? Index { get; set; } = null;
    }
}
