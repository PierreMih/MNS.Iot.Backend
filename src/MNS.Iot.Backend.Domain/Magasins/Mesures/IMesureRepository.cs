using System;
using MNS.Iot.Backend.Magasins.Sondes;
using Volo.Abp.Domain.Repositories;

namespace MNS.Iot.Backend.Magasins.Mesures;

public interface IMesureRepository : IRepository<Mesure, Guid>
{
    
}