using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PackagingAutomation.Utilities;

namespace PackagingAutomation.Models.Entities
{
    public enum ReconfigType
    {
        [Description("Нет")]
        None,
        [Description("Замена упаковочной плёнки")]
        Wrapping,
        [Description("Полная")]
        Full
    }

    [DisplayName("Расписание")]
    public class ProductionSchedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("PackagingMachine")]
        [DisplayName("Упаковочный автомат")]
        public int MachineId { get; set; }
        [DisplayName("Упаковочный автомат")]
        public PackagingMachine? Machine { get; set; }

        [ForeignKey("Order")]
        [DisplayName("Заказ")]
        public int? OrderId { get; set; }
        [DisplayName("Заказ")]
        public Order? Order { get; set; }

        [Required]
        [DisplayName("Тип переналадки")]
        public ReconfigType ReconfigType { get; set; } = ReconfigType.None;

        [Required]
        [DisplayName("Время начала")]
        public DateTime StartTime { get; set; }

        [Required]
        [DisplayName("Время завершения")]
        public DateTime EndTime { get; set; }

        [NotMapped]
        [DisplayName("Длительность")]
        public TimeSpan Duration => EndTime - StartTime;

        [NotMapped]
        [DisplayName("Тип переналадки")]
        public string GetReconfigType => EnumHelper.GetDescription(ReconfigType);

        [NotMapped]
        [DisplayName("Расписания")]
        public string? Index { get; set; } = null;
    }
}
