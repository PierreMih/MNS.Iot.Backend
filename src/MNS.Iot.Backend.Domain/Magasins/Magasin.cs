using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins {
    public class Magasin : FullAuditedAggregateRoot<Guid> {
        public List<MagasinPasserelleJoinEntity> MagasinPasserelleJoinEntities { get; set; }

        // public void AjouterMesure(Guid passerelleId, Guid machineId, Guid sondeId, double temperature) {
        //     Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
        //     passerelle.AjouterMesure(machineId, sondeId, temperature);
        // }
        //
        // public IEnumerable<Machine> RecupererMachines(Guid passerelleId) {
        //     Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
        //     return passerelle.RecupererMachines();
        // }
        //
        // public IEnumerable<Sonde> RecupererSondes(Guid passerelleId, Guid machineId) {
        //     Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
        //     return passerelle.RecupererSondes(machineId);
        // }
        //
        // public IEnumerable<Mesure> RecupererMesures(Guid passerelleId, Guid machineId, Guid sondeId) {
        //     Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
        //     return passerelle.RecupererMesures(machineId, sondeId);
        // }

    }
}
