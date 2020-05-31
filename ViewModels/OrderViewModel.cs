using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.ViewModels
{
    public class OrderViewModel
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public string orderNumber { get; set; }
        public IEnumerable<OrderItemViewModel> items { get; set; }
    }
}
