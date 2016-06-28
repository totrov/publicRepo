using System.Collections.Generic;

namespace DAL.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Fio { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
