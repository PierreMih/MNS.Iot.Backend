﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Sondes.DTOs.Inputs {
    public class SondeTemperatureDto {
        public string Sonde_id {  get; set; }
        public double Temperature { get; set; }
        public long Timestamp { get; set; }
    }
}
