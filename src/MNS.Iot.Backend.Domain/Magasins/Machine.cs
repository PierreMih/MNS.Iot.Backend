using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins {
    public class Machine : Entity<Guid> {
        public List<Sonde> Sondes { get; set; }

        public void AjouterMesure(Guid sondeId, double temperature) {
            Sonde sonde = Sondes.First((p) => p.Id == sondeId);
            sonde.AjouterMesure(temperature);
        }  

        public IEnumerable<Mesure> RecupererMesures(Guid sondeId) {
            Sonde sonde = Sondes.First((s) => s.Id == sondeId);
            return sonde.RecupererMesures();
        }

        public IEnumerable<Sonde> RecupererSondes() {
            return Sondes;
        }
    }
}
