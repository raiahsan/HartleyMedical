using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HartleyMedical.Application.Common.Models
{
    public class RecordSet<T>
    {
        public int TotalRows { set; get; }
        public IList<T> Items { set; get; }
    }
}
