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

public class PasserelleRepository : EfCoreRepository<BackendDbContext, Passerelle, Guid>, IPasserelleRepository
{
    public PasserelleRepository(IDbContextProvider<BackendDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
    public override async Task<IQueryable<Passerelle>> WithDetailsAsync()
    {
        return (await base.WithDetailsAsync())
            .Include( p => p.Machines)
            .ThenInclude(m => m.Sondes)
            .ThenInclude(s => s.Mesures);;
    }
}