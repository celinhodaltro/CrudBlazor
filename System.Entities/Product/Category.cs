using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Entities.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Entities
{
    public class Category :DefaultDb
    {

        [StringLength(50, ErrorMessage = "The product description cannot be longer than 50 characters.")]
        public string Name { get; set; } = "";

        [StringLength(500, ErrorMessage = "The product description cannot be longer than 500 characters.")]
        public string Description { get; set; } = "";
    }
}
