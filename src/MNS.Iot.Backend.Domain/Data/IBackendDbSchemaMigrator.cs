using System.Threading.Tasks;

namespace MNS.Iot.Backend.Data;

public interface IBackendDbSchemaMigrator
{
    Task MigrateAsync();
}
