using Simulation4.Models.Common;

namespace Simulation4.Models
{
    public class Person:BaseEntity
    {
        public  string Name { get; set; }
        public string ImagePath { get; set; }
        public  string  Words { get; set; }
        public int PositionId { get; set; }
        public  Position Position  { get; set; }
    }
}
