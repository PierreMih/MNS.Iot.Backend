using MNS.Iot.Backend.Samples;
using Xunit;

namespace MNS.Iot.Backend.EntityFrameworkCore.Domains;

[Collection(BackendTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BackendEntityFrameworkCoreTestModule>
{

}
