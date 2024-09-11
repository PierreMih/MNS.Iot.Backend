using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Sondes.DTOs.Inputs {
    public class MoveSondeToAnotherMachineDto {
        public Guid SondeId { get; set; }
        public Guid NewMachineId { get; set; }
    }
}
