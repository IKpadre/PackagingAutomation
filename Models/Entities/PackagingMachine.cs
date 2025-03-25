using PackagingAutomation.Utilities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PackagingAutomation.Models.Entities
{
    public enum MachineStatus
    {
        [Description("Доступен")]
        Available,
        [Description("Отключен")]
        Disabled,
        [Description("Обслуживается")]
        Maintenance,
        [Description("Выведен из строя")]
        Broken
    }

    [DisplayName("Упаковочный автомат")]
    public class PackagingMachine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Название")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DisplayName("Статус")]
        public MachineStatus Status { get; set; } = MachineStatus.Available;

        [Required]
        [ForeignKey("ProductionLine")]
        [DisplayName("Производственная линия")]
        public int ProductionLineId { get; set; }
        [DisplayName("Производственная линия")]
        public ProductionLine? ProductionLine { get; set; }

        [ForeignKey("Product")]
        [DisplayName("Продукция")]
        public int? ProductId { get; set; }
        [DisplayName("Продукция")]
        public Product? Product { get; set; }

        [DisplayName("Расписания")]
        public List<ProductionSchedule> Schedules { get; set; } = new();

        [NotMapped]
        [DisplayName("Статус")]
        public string GetStatus => EnumHelper.GetDescription(Status);

        [NotMapped]
        [DisplayName("Упаковочные автоматы")]
        public string? Index { get; set; } = null;
    }
}
