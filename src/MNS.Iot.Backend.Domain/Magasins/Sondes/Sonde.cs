// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Volo.Abp.Domain.Entities;
// using Volo.Abp.Domain.Entities.Auditing;
//
// namespace MNS.Iot.Backend.Magasins.Sondes {
//     public class Sonde : FullAuditedAggregateRoot<Guid> {
//         public List<Mesure> Mesures { get; set; }
//
//         public string IdPhysique { get; set; }
//
//         protected Sonde()
//         {
//             
//         }
//         public Sonde(IEnumerable<Mesure> mesures, string idPhysique) {
//             Mesures = mesures.ToList();
//             IdPhysique = idPhysique;
//         }
//
//         // public void AjouterMesure(double temperature) {
//         //     Mesures.Add(new Mesure(temperature));
//         // }
//     }
// }
