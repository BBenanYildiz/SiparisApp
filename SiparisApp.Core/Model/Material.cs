using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisApp.Core.Model
{
    public class Material:BaseEntity
    {
        public string mat_kodu { get; set; }
        public string mat_adi { get; set; }
    }
}
