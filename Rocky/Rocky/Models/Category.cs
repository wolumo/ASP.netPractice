﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky.Models
{
    public class Category
    {
        [Key] //Simboliza la llave foranea
        public int Id { get; set; }

        [Required]

        public string Name { get; set; }

        
        [DisplayName("Display Order")]

        [Required]

        [Range(1, int.MaxValue, ErrorMessage ="Display Order for category must be greater than 0 ")]
        public int DisplayOrder { get; set; }

    }
}
