using Volo.Abp.Modularity;

namespace MNS.Iot.Backend;

[DependsOn(
    typeof(BackendApplicationModule),
    typeof(BackendDomainTestModule)
)]
public class BackendApplicationTestModule : AbpModule
{

}
