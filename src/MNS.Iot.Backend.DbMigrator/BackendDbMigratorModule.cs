using MNS.Iot.Backend.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MNS.Iot.Backend.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BackendEntityFrameworkCoreModule),
    typeof(BackendApplicationContractsModule)
    )]
public class BackendDbMigratorModule : AbpModule
{
}
