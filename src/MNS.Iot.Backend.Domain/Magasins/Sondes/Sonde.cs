using System;
using System.Collections.Generic;
using System.Linq;
using MNS.Iot.Backend.Magasins.Machines;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins.Sondes {
    public class Sonde : FullAuditedAggregateRoot<Guid> {
        public List<Mesure> Mesures { get; set; }

        public string IdPhysique { get; set; }

        public string Name { get; set; }
        
        public Guid MachineId { get; set; }
        public Machine Machine { get; set; } = null!;

        protected Sonde()
        {
            Mesures = new();
        }
        public Sonde(Guid id, Machine machine, string idPhysique, string name): base(id) {
            MachineId = machine.Id;
            Machine = machine;
            IdPhysique = idPhysique;
            Name = name;
            Mesures = new();
        }

        // public void AjouterMesure(double temperature) {
        //     Mesures.Add(new Mesure(temperature));
        // }
    }
}
