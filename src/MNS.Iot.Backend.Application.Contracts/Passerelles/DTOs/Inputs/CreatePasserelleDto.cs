using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MNS.Iot.Backend.Passerelles.DTOs.Inputs
{
    public class CreatePasserelleDto
    {
        public string Name { get; set; }
        public string IdPhysique { get; set; }

        public Guid MagasinId { get; set; }
    }
}
