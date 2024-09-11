using System;
using System.Collections.Generic;
using MNS.Iot.Backend.Magasins.DTOs.Outputs;
using MNS.Iot.Backend.Mesures.DTOs.Outputs;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Sondes.DTOs.Outputs
{
    public class SondeDto : EntityDto<Guid>
    {
        public List<MesureDto> Mesures { get; set; }

        public string IdPhysique { get; set; }
        
        public string Name { get; set; }
    }
}
