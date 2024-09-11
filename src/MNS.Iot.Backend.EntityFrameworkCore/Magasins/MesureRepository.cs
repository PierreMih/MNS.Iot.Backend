using System;
using MNS.Iot.Backend.EntityFrameworkCore;
using MNS.Iot.Backend.Magasins.Mesures;
using MNS.Iot.Backend.Magasins.Sondes;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MNS.Iot.Backend.Magasins;

public class MesureRepository : EfCoreRepository<BackendDbContext, Mesure, Guid> , IMesureRepository
{
    public MesureRepository(IDbContextProvider<BackendDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}