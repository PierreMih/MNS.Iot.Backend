using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Magasins.DTOs.Outputs
{
    public class MagasinDto : EntityDto<Guid>
    {
        public List<PasserelleDto> Passerelles { get; set; }
        public string Name { get; set; }
    }
}
