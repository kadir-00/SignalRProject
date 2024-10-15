using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRUI.Dtos.DiscountDtos
{
    public class GetDiscountDto
    {
        public int DiscountId { get; set; }
        public string Title { get; set; }
        public string Amount { get; set; }
        public string Deescription { get; set; }
        public string ImageUrl { get; set; }
    }
}
