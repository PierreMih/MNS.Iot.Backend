using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MNS.Iot.Backend.EntityFrameworkCore;
using MNS.Iot.Backend.Magasins.Passerelles;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MNS.Iot.Backend.Magasins;

public class MagasinRepository : EfCoreRepository<BackendDbContext, Magasin, Guid>, IMagasinRepository
{
    public MagasinRepository(IDbContextProvider<BackendDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    // public async Task<Magasin> GetMagasinByPasserelleId(Guid passerelleId) {
    //     var query = await GetQueryableAsync();
    //     return query.First(m => m.MagasinPasserelleJoinEntities.Any( je => je.PasserelleId == passerelleId));
    // }
}