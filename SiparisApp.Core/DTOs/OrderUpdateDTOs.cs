﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisApp.Core.DTOs
{
    public class OrderStatusUpdateDTOs
    {
        public string ord_musteri_no { get; set; }
        public string ord_durum { get; set; }
        public DateTime ord_degisim_tarihi { get; set; } = DateTime.Now;
    }
}
