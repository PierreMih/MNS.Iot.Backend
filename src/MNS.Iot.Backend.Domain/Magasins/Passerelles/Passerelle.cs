using System;
using System.Collections.Generic;
using System.Linq;
// using MNS.Iot.Backend.Magasins.Machines;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins.Passerelles {
    public class Passerelle : FullAuditedEntity<Guid> {

        public Passerelle()
        {
            // Machines = new();
        }
        public Passerelle(Guid id, Magasin magasin, string idPhysique, string name): base(id) {
            MagasinId = magasin.Id;
            Magasin = magasin;
            IdPhysique = idPhysique;
            Name = name;
            // Machines = new();
        }

        public Guid MagasinId { get; set; }
        public Magasin Magasin { get; set; } = null!;
        public string IdPhysique { get; set; }
        public string Name { get; set; }
        // public List<Machine> Machines { get; set; }

        // public void AjouterMesure(Guid machineId, Guid sondeId, double temperature) {
        //     Machine machine = Machines.First((m) => m.Id == machineId);
        //     machine.AjouterMesure(sondeId, temperature);
        // }
        // public IEnumerable<Sonde> RecupererSondes(Guid machineId) {
        //     Machine machine = Machines.First((m) => m.Id == machineId);
        //     return machine.RecupererSondes();
        // }
        //
        // public IEnumerable<Mesure> RecupererMesures(Guid machineId, Guid sondeId) {
        //     Machine machine = Machines.First((m) => m.Id == machineId);
        //     return machine.RecupererMesures(sondeId);
        // }
        //
        // internal IEnumerable<Machine> RecupererMachines() {
        //     return Machines;
        // }
    }
}
