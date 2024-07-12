using Volo.Abp.Modularity;

namespace MNS.Iot.Backend;

public abstract class BackendApplicationTestBase<TStartupModule> : BackendTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
