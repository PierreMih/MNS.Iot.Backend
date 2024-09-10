using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Magasins.DTOs.Outputs
{
    public class SondeDto : EntityDto<Guid>
    {
        public List<MesureDto> Mesures { get; set; }

        public string IdPhysique { get; set; }
    }
}
