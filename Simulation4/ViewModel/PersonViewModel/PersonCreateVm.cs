using Simulation4.Models;
namespace Simulation4.ViewModel.PersonViewModel
{
    public class PersonCreateVm
    {
       public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Words { get; set; }
        public int PositionId { get; set; }

    }
}
