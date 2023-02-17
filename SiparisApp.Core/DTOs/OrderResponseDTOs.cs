using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisApp.Core.DTOs
{
    public class OrderResponseDTOs
    {
        public string ord_musteri_no { get; set; }
        public int ord_sistem_no { get; set; }
        public int ord_statu { get; set; }
        public string ord_hata_aciklama { get;set; }
    }
}
