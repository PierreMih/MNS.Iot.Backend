using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins {
    public class Magasin : Entity<Guid> {
        public List<Passerelle> Passerelles { get; set; }

        public Magasin(List<Passerelle> passerelles) {
            Passerelles = passerelles;
        }

        public void AjouterMesure(Guid passerelleId, Guid sondeId, double temperature) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            passerelle.AjouterMesure(sondeId, temperature);
        }

        public IEnumerable<Sonde> RecupererSondes(Guid passerelleId) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            return passerelle.RecupererSondes();
        }

        public IEnumerable<Mesure> RecupererMesures(Guid passerelleId, Guid sondeId) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            return passerelle.RecupererMesures(sondeId);
        }

    }
}
