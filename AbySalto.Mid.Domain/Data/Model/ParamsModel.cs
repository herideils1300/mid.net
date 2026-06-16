using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbySalto.Mid.Domain.Data.Model
{
    public class ParamsModel
    {
        public ParamsModel(int page, string? querry, Order? orderBy, string? sortElements)
        {
            Querry = querry;
            OrderBy = orderBy;
            Page = page;
            SortElements = sortElements;
        }

        public int Page { get; set; }
        public string? Querry { get; set; }
        public Order? OrderBy { get; set; } = Order.Desc;
        public string? SortElements { get; set; }
    }
}
