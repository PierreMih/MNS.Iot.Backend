using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins.Passerelles {
    public class Passerelle : FullAuditedAggregateRoot<Guid> {
        public Passerelle(Guid id, string idPhysique, string name): base(id) {
            IdPhysique = idPhysique;
            Name = name;
        }

        public string IdPhysique { get; set; }
        public string Name { get; set; }
        public List<PasserelleMachineJoinEntity> MachinePasserelleJoinEntities { get; set; }

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
