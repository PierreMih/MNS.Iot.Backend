﻿using Volo.Abp.Settings;

namespace MNS.Iot.Backend.Settings;

public class BackendSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BackendSettings.MySetting1));
    }
}
