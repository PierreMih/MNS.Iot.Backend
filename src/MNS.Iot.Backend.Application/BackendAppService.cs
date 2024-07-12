using System;
using System.Collections.Generic;
using System.Text;
using MNS.Iot.Backend.Localization;
using Volo.Abp.Application.Services;

namespace MNS.Iot.Backend;

/* Inherit your application services from this class.
 */
public abstract class BackendAppService : ApplicationService
{
    protected BackendAppService()
    {
        LocalizationResource = typeof(BackendResource);
    }
}
