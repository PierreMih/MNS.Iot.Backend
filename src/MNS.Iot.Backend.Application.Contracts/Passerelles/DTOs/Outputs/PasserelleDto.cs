using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using MNS.Iot.Backend.Machines.DTOs.Outputs;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Magasins.DTOs.Outputs
{
    public class PasserelleDto : EntityDto<Guid>
    {
        public List<MachineDto> Machines { get; set; }
    }
}
