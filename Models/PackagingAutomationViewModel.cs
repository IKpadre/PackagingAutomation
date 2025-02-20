using PackagingAutomation.Models.Entities;
using System.ComponentModel;

namespace PackagingAutomation.Models
{
    [DisplayName("Автоматизация упаковки")]
    public class PackagingAutomationViewModel
    {
        [DisplayName("Заказы")]
        public IEnumerable<Order> Orders { get; set; } = [];
        [DisplayName("Упаковочные автоматы")]
        public IEnumerable<PackagingMachine> PackagingMachines { get; set; } = [];
    }
}
