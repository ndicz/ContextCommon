using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextBack
{
    public class GetOrderListDbParameterDTO
    {
        public string CompanyId { get; set; }
        public string DepartmentId { get; set; }
        public string SalesId { get; set; }
        public int OrderCount { get; set; }
    }
}
