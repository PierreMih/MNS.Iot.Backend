using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

    public override async Task<IQueryable<Magasin>> WithDetailsAsync()
    {
        return (await base.WithDetailsAsync()).Include( m => m.Passerelles);
    }
}