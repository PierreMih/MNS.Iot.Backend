using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MNS.Iot.Backend.Magasins.Passerelles;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins {
    public class Magasin : FullAuditedEntity<Guid> {
        public Magasin(Guid id, string name) : base(id) {
            Name = name;
            Passerelles = new();
        }

        public string Name { get; set; }
        public List<Passerelle> Passerelles { get; set; 
    }
}
