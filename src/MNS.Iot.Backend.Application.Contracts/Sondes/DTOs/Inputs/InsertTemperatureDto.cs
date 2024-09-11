using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Sondes.DTOs.Inputs {
    public class InsertTemperatureDto {
        private string Sonde_id {  get; set; }
        private string Temperature { get; set; }
        
        private string Timestamp { get; set; }
    }
}
