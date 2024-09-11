using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Sondes.DTOs.Inputs {
    public class SondeBatchDto {
        public string PasserellePhysicalId { get; set; }
        public List<SondeTemperatureDto> SondeTemperatureDtoList { get; set; }
    }
}
