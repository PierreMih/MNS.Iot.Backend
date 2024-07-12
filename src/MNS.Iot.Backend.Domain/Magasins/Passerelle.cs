using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins {
    public class Passerelle : Entity<Guid> {
        public List<Sonde> Sondes { get; set; }

        public Passerelle(List<Sonde> sondes) {
            Sondes = sondes;
        }

        public void AjouterMesure(Guid sondeId, double temperature) {
            Sonde sonde = Sondes.First((s) => s.Id == sondeId);
            sonde.AjouterMesure(temperature);
        }
        public IEnumerable<Sonde> RecupererSondes() {
            return Sondes;
        }

        public IEnumerable<Mesure> RecupererMesures(Guid sondeId) {
            Sonde sonde = Sondes.First((s) => s.Id == sondeId);
            return sonde.RecupererMesures();
        }

    }
}
