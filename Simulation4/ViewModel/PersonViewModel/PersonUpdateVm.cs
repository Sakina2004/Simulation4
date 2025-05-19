namespace Simulation4.ViewModel.PersonViewModel
{
    public class PersonUpdateVm
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string Words { get; set; }
        public int PositionId { get; set; }
    }
}
