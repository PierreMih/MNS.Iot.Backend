// using System;
// using System.Collections.Generic;
// using MNS.Iot.Backend.Magasins.Sondes;
// using Volo.Abp.Domain.Entities.Auditing;
//
// namespace MNS.Iot.Backend.Magasins.Machines {
//     public class Machine : FullAuditedAggregateRoot<Guid> {
//         
//         public Machine(string idPhysique, string name /*, List<Sonde> sondes*/)
//         {
//             IdPhysique = idPhysique;
//             Name = name;
//             // Sondes = sondes;
//         }
//
//         // public List<Sonde> Sondes { get; set; }
//         public string Name { get; set; }
//         public string IdPhysique { get; set; }
//         
//
//         // public void AjouterMesure(Guid sondeId, double temperature) {
//         //     Sonde sonde = Sondes.First((p) => p.Id == sondeId);
//         //     sonde.AjouterMesure(temperature);
//         // }  
//         //
//         // public IEnumerable<Mesure> RecupererMesures(Guid sondeId) {
//         //     Sonde sonde = Sondes.First((s) => s.Id == sondeId);
//         //     return sonde.RecupererMesures();
//         // }
//         //
//         // public IEnumerable<Sonde> RecupererSondes() {
//         //     return Sondes;
//         // }
//     }
// }
