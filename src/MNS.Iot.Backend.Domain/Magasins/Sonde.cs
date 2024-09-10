using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins {
    public class Sonde : Entity<Guid> {
        public List<Mesure> Mesures { get; set; }

        public string idPhysique { get; set; }

        public Sonde(List<Mesure> mesures, string idPhysique) {
            Mesures = mesures;
            this.idPhysique = idPhysique;
        }

        public void AjouterMesure(double temperature) {
            Mesures.Add(new Mesure(temperature));
        }

        internal IEnumerable<Mesure> RecupererMesures() {
            return Mesures;
        }
    }
}
