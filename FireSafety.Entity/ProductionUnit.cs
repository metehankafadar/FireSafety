using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FireSafety.Entity
{
    [Table("ProductionUnits")]
    public class ProductionUnit : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        
    }
}
