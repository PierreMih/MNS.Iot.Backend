using System;
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
    
}