using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins {
    public class Magasin : Entity<Guid> {
        public List<Passerelle> Passerelles { get; set; }

        public Magasin(List<Passerelle> passerelles) {
            Passerelles = passerelles;
        }

        public void AjouterMesure(Guid passerelleId, Guid machineId, Guid sondeId, double temperature) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            passerelle.AjouterMesure(machineId, sondeId, temperature);
        }

        public IEnumerable<Machine> RecupererMachines(Guid passerelleId) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            return passerelle.RecupererMachines();
        }

        public IEnumerable<Sonde> RecupererSondes(Guid passerelleId, Guid machineId) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            return passerelle.RecupererSondes(machineId);
        }

        public IEnumerable<Mesure> RecupererMesures(Guid passerelleId, Guid machineId, Guid sondeId) {
            Passerelle passerelle = Passerelles.First((p) => p.Id == passerelleId);
            return passerelle.RecupererMesures(machineId, sondeId);
        }

    }
}
