using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Sondes.DTOs.Inputs {
    public class SondeTemperatureDto {
        public string Sonde_id {  get; set; }
        public string Temperature { get; set; }
        public string Timestamp { get; set; }
    }
}
