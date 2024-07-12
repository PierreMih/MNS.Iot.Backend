using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MNS.Iot.Backend;

[Dependency(ReplaceServices = true)]
public class BackendBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Backend";
}
