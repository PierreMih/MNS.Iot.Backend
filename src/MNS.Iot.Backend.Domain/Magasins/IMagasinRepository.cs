using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MNS.Iot.Backend.Magasins {
    public interface IMagasinRepository : IRepository<Magasin, Guid> {
    }

}
