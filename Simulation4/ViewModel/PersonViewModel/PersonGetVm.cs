using Simulation4.Models.Common;
using Simulation4.ViewModel.PositionViewModel;

namespace Simulation4.ViewModel.PersonViewModel
{
    public class PersonGetVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string  Words { get; set; }
        public int  PositionId { get; set; }
        public PositionGetVm Position { get; set; }
    }
}