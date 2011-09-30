﻿using System.Collections.Generic;
using Inceptum.AppServer.Configuration;

namespace Inceptum.AppServer
{
    internal interface IApplicationHost
    {
        void Start(IConfigurationProvider configurationProvider);
        void Stop();
    }
}