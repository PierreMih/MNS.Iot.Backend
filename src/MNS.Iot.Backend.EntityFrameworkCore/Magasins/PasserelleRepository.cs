using System;
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
}