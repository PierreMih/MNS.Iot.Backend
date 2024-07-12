using Volo.Abp.Modularity;

namespace MNS.Iot.Backend;

[DependsOn(
    typeof(BackendDomainModule),
    typeof(BackendTestBaseModule)
)]
public class BackendDomainTestModule : AbpModule
{

}
