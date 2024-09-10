using System;
using Volo.Abp.Domain.Repositories;

namespace MNS.Iot.Backend.Magasins.Sondes;

public interface ISondeRepository : IRepository<Sonde,Guid>
{
    
}