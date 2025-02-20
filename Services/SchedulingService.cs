using PackagingAutomation.Models.Entities;

namespace PackagingAutomation.Services
{
    public static class SchedulingService
    {
        const int baseReconfigTime = 30;

        public static List<ProductionSchedule> GenerateSchedule(List<Order> orders, List<PackagingMachine> machines)
        {
            List<ProductionSchedule> schedule = new();
            DateTime baseTime = DateTime.Now;

            var availableTimes = machines.Where(m => m.Status == MachineStatus.Available).ToDictionary(m => m.Id, m => baseTime);
            var sortedOrders = orders.OrderBy(o => o.Priority).ThenBy(o => o.Deadline).ToList();

            foreach (var order in sortedOrders)
            {
                var product = order.Product;
                PackagingMachine? selectedMachine = null;
                int minReconfigCost = int.MaxValue;
                DateTime selectedStartTime = baseTime;
                DateTime selectedEndTime = baseTime;
                int selectedReconfigTime = 0;

                foreach (var machine in machines.Where(m => m.Status == MachineStatus.Available))
                {
                    DateTime availableTime = availableTimes[machine.Id];
                    int reconfigCost = 0;

                    if (machine.Product == null)
                    {
                        reconfigCost = 2;
                    }
                    else if (machine.Product.Id == product.Id)
                    {
                        reconfigCost = 0;
                    }
                    else if (machine.Product.Weight.FormatTubeId == product.Weight.FormatTubeId)
                    {
                        reconfigCost = 1;
                    }
                    else
                    {
                        reconfigCost = 2;
                    }

                    int reconfigTime = baseReconfigTime * reconfigCost;
                    DateTime startTime = availableTime.AddMinutes(reconfigTime);
                    DateTime endTime = startTime.AddMinutes(order.Quantity / product.Weight.Performance);

                    if (endTime > order.Deadline)
                    {
                        continue;
                    }

                    if (reconfigCost < minReconfigCost || (reconfigCost == minReconfigCost && availableTime < selectedStartTime))
                    {
                        minReconfigCost = reconfigCost;
                        selectedMachine = machine;
                        selectedStartTime = startTime;
                        selectedEndTime = endTime;
                        selectedReconfigTime = reconfigTime;
                    }
                }

                if (selectedMachine != null)
                {
                    if (selectedReconfigTime > 0)
                    {
                        schedule.Add(new ProductionSchedule
                        {
                            Machine = selectedMachine,
                            Order = null,
                            StartTime = availableTimes[selectedMachine.Id],
                            EndTime = availableTimes[selectedMachine.Id].AddMinutes(selectedReconfigTime),
                            ReconfigType = (ReconfigType)minReconfigCost
                        });
                    }

                    schedule.Add(new ProductionSchedule
                    {
                        Machine = selectedMachine,
                        Order = order,
                        StartTime = selectedStartTime,
                        EndTime = selectedEndTime
                    });

                    availableTimes[selectedMachine.Id] = selectedEndTime;
                    selectedMachine.Product = product;
                }
            }

            return schedule;
        }

    }
}
