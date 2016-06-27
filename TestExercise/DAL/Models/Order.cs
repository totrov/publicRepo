using System.Collections.Generic;

namespace DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public virtual ICollection<OrderUnit> OrderUnit { get; set; }

    }
}