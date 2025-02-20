using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    [DisplayName("Форматная труба")]
    public class FormatTube
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Фасовки")]
        public List<Weight> Weights { get; set; } = new();

        [NotMapped]
        [DisplayName("Форматные трубы")]
        public string? Index { get; set; } = null;
    }
}
