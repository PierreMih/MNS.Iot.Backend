using System;
using MNS.Iot.Backend.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MNS.Iot.Backend.Magasins;

public class MagasinRepository : EfCoreRepository<BackendDbContext, Magasin, Guid>, IMagasinRepository
{
    public MagasinRepository(IDbContextProvider<BackendDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}