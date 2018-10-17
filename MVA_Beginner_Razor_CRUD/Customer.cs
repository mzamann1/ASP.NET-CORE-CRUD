
using System.ComponentModel.DataAnnotations;

namespace MVA_Beginner_Razor_CRUD
{
    public class Customer
    {

        public int Id { get; set; }

        [Required,StringLength(10)]
        public string Name { get; set; }
    }
}