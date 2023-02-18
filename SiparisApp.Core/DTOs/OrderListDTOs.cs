using SiparisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisApp.Core.DTOs
{
    public class OrderListDTOs
    {
        public string Id { get; set; }
        public string ord_musteri_no { get; set; }
        public string ord_cikis_adres { get; set; }
        public string ord_varis_adres { get; set; }
        public double ord_miktar { get; set; }
        public string ord_miktar_birim { get; set; }
        public double ord_agirlik { get; set; }
        public string ord_agirlik_birim { get; set; }
        public string ord_malzeme_kodu { get; set; }
        public string ord_malzeme_adi { get; set; }
        public string ord_not { get; set; }
        public string ord_durum { get; set; }
        public OrderStatus OrderStatuses { get; set; }
    }
}
