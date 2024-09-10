using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;

namespace MNS.Iot.Backend.Magasins.Passerelles;

public interface IPasserelleRepository : IRepository<Passerelle, Guid>
{
}