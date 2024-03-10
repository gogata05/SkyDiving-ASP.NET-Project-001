using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skydiving.Core.ViewModels.Equipment
{
    public class AllEquipmentsQueryModel
    {
        public const int EquipmentsPerPage = 3;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public EquipmentSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalEquipmentsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<EquipmentViewModel> Equipments { get; set; } = Enumerable.Empty<EquipmentViewModel>();
    }
}
