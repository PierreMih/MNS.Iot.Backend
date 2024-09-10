using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace MNS.Iot.Backend.Magasins.Machines {
    public class Machine : FullAuditedAggregateRoot<Guid> {
        public List<MachineSondeJoinEntity> MachineSondeJoinEntities { get; set; }

        // public void AjouterMesure(Guid sondeId, double temperature) {
        //     Sonde sonde = Sondes.First((p) => p.Id == sondeId);
        //     sonde.AjouterMesure(temperature);
        // }  
        //
        // public IEnumerable<Mesure> RecupererMesures(Guid sondeId) {
        //     Sonde sonde = Sondes.First((s) => s.Id == sondeId);
        //     return sonde.RecupererMesures();
        // }
        //
        // public IEnumerable<Sonde> RecupererSondes() {
        //     return Sondes;
        // }
    }
}
