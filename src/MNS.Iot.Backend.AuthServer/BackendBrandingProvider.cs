using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MNS.Iot.Backend;

[Dependency(ReplaceServices = true)]
public class BackendBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Backend";
}
