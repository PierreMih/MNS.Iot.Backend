using MNS.Iot.Backend.Samples;
using Xunit;

namespace MNS.Iot.Backend.EntityFrameworkCore.Applications;

[Collection(BackendTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BackendEntityFrameworkCoreTestModule>
{

}
