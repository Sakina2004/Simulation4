using Simulation4.Models.Common;

namespace Simulation4.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Position> Positions {  get; set; }
       
        
    }
}
