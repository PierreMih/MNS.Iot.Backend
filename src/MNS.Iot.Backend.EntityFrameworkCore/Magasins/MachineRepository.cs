using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MNS.Iot.Backend.EntityFrameworkCore;
using MNS.Iot.Backend.Magasins.Machines;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MNS.Iot.Backend.Magasins;

public class MachineRepository : EfCoreRepository<BackendDbContext, Machine, Guid>, IMachineRepository
{
    public MachineRepository(IDbContextProvider<BackendDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Machine>> WithDetailsAsync()
    {
        return (await base.WithDetailsAsync()).Include( m => m.Sondes);
    }
}