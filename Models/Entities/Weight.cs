using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Фасовка")]
    public class Weight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Грамм")]
        public uint Grams { get; set; }

        [Required]
        [DisplayName("Пакетов / мин.")]
        public uint Performance { get; set; }

        [Required]
        [ForeignKey("FormatTube")]
        [DisplayName("Форматная труба")]
        public int FormatTubeId { get; set; }
        [DisplayName("Форматная труба")]
        public FormatTube? FormatTube { get; set; }

        [DisplayName("Продукция")]
        public List<Product> Products { get; set; } = new();

        [NotMapped]
        [DisplayName("Фасовки")]
        public string? Index { get; set; } = null;
    }
}
