using System;
using System.Collections.Generic;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Machines.DTOs.Outputs
{
    public class MachineDto : EntityDto<Guid>
    {
        public Guid PasserelleId { get; set; }
        public string Name { get; set; }
        public string IdPhysique { get; set; }
        public List<SondeDto> Sondes { get; set; }
    }
}
