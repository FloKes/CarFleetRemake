using System.ComponentModel.DataAnnotations;

namespace CarFleet.Domain
{
    public class Car
    {

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Engine { get; set; }
    }
}
