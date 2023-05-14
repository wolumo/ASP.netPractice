
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class AplicationType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
