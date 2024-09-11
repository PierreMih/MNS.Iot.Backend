using System;
using Volo.Abp.Domain.Repositories;

namespace MNS.Iot.Backend.Magasins.Machines;

public interface IMachineRepository : IRepository<Machine, Guid>
{
    
}