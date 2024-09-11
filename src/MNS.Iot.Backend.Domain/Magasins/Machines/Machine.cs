using System;
using System.Collections.Generic;
using MNS.Iot.Backend.Magasins.Passerelles;
using MNS.Iot.Backend.Magasins.Sondes;
// using MNS.Iot.Backend.Magasins.Sondes;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins.Machines {
    public class Machine : FullAuditedAggregateRoot<Guid> {

        public Machine()
        {
            Sondes = new();
        }
        public Machine(Guid id, Guid passerelleId, string idPhysique, string name) : base(id)
        {
            PasserelleId = passerelleId;
            IdPhysique = idPhysique;
            Name = name;
            Sondes = new();
        }

        public Guid PasserelleId { get; set; }
        public Passerelle Passerelle { get; set; } = null!;
        public List<Sonde> Sondes { get; set; }
        public string Name { get; set; }
        public string IdPhysique { get; set; }
    }
}
