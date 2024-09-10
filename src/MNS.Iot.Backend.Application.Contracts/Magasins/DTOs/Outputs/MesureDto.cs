using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Magasins.DTOs.Outputs
{
    public class MesureDto : EntityDto<Guid>
    {
        public double Temperature { get; set; }
    }
}
