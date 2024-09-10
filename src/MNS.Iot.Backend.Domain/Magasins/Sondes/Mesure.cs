using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Domain.Values;

namespace MNS.Iot.Backend.Magasins.Sondes {
    public class Mesure : ValueObject{
        public double Temperature { get; set; }
        public DateTime Date { get; set; }

        public Mesure(double temperature)
        {
            Temperature = temperature;
            Date = DateTime.Now;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            return new List<object> { Temperature, Date };
        }
    }
}
