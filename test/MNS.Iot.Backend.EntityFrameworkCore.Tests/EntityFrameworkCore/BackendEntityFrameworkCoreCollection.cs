using Xunit;

namespace MNS.Iot.Backend.EntityFrameworkCore;

[CollectionDefinition(BackendTestConsts.CollectionDefinitionName)]
public class BackendEntityFrameworkCoreCollection : ICollectionFixture<BackendEntityFrameworkCoreFixture>
{

}
