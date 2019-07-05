using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.EntityLayer
{
    public abstract class SozObek
    {
        public int Id { get; set; }
        public string DeyisCumle { get; set; }
        public string DeyisAnlami { get; set; }
    }
}
