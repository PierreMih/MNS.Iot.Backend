using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Application.Dtos;

namespace MNS.Iot.Backend.Magasins {
    public class MachineDto: EntityDto<Guid> {
        public List<SondeDto> Sondes { get; set; }
    }
}
