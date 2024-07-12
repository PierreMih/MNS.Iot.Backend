using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins {
    public class Mesure : AuditedEntity<Guid> {
        public double Temperature { get; set; }

        public Mesure(double temperature) {
            Temperature = temperature;
        }
    }
}
