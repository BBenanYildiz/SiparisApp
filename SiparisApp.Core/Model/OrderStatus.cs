using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisApp.Core.Model
{
    public class OrderStatus:BaseEntity
    {
        public string ord_sta_musteri_no { get; set; }

        /// <summary>
        /// Sipariş Alındı, Yola Çıktı, Dağıtım Merkezinde, Dağıtıma Çıktı, Teslim Edildi, Teslim Edilemedi
        /// </summary>
        public string ord_sta_durum { get; set; }
        public DateTime ord_sta_degisim_tarihi { get; set; }

        public int OrderId { get; set; }
    }
}
