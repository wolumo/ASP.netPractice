
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class AplicationType
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "El nombre es obligatorio.")]
        public string Name { get; set; }
    }
}
