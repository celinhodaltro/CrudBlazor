using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Entities.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Entities
{
    public class Stock : DefaultDb
    {

        [Range(1, int.MaxValue, ErrorMessage = "Stock must have a Product!")]
        int ProductId { get; set; }

        [ForeignKey("ProductId")]
        Product Product { get; set; } = new();
        int Quantity { get; set; }
    }
}
