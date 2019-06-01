﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Condensate_API.Services
{
    // A hack to allow IHostedServices to be injected. Courtesy of https://stackoverflow.com/a/51314147/7121207
    public class BackgroundServiceStarter<T> : IHostedService where T : IHostedService
    {
        readonly T backgroundService;

        public BackgroundServiceStarter(T backgroundService)
        {
            this.backgroundService = backgroundService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return backgroundService.StartAsync(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return backgroundService.StopAsync(cancellationToken);
        }
    }
}
