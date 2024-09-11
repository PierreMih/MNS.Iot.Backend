using System;
using System.Collections.Generic;
using MNS.Iot.Backend.Magasins.Machines;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace MNS.Iot.Backend.Magasins.Sondes {
    public class Mesure : FullAuditedAggregateRoot<Guid>{
        public double Temperature { get; set; }
        public DateTime Date { get; set; }
        public Guid SondeId { get; set; }
        public Sonde Sonde { get; set; } = null!;

        public Mesure(Guid id, Sonde sonde, double temperature, DateTime date) : base(id)
        {
            Temperature = temperature;
            Date = date;
            SondeId = sonde.Id;
            Sonde = sonde;
        }

        public Mesure()
        {
            
        }
    }
}
