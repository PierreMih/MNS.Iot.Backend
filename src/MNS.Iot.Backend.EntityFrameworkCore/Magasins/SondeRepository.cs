using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MNS.Iot.Backend.EntityFrameworkCore;
using MNS.Iot.Backend.Magasins.Sondes;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MNS.Iot.Backend.Magasins;

public class SondeRepository : EfCoreRepository<BackendDbContext, Sonde, Guid>, ISondeRepository
{
    public SondeRepository(IDbContextProvider<BackendDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Sonde>> WithDetailsAsync()
    {
        return (await base.WithDetailsAsync()).Include( s => s.Mesures);
    }
}