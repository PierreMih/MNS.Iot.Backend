using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MNS.Iot.Backend.Magasins {
    public class Passerelle : Entity<Guid> {
        public List<Machine> Machines { get; set; }

        public Passerelle(List<Machine> machines) {
            Machines = machines;
        }

        public void AjouterMesure(Guid machineId, Guid sondeId, double temperature) {
            Machine machine = Machines.First((m) => m.Id == machineId);
            machine.AjouterMesure(sondeId, temperature);
        }
        public IEnumerable<Sonde> RecupererSondes(Guid machineId) {
            Machine machine = Machines.First((m) => m.Id == machineId);
            return machine.RecupererSondes();
        }

        public IEnumerable<Mesure> RecupererMesures(Guid machineId, Guid sondeId) {
            Machine machine = Machines.First((m) => m.Id == machineId);
            return machine.RecupererMesures(sondeId);
        }

        internal IEnumerable<Machine> RecupererMachines() {
            return Machines;
        }
    }
}
