using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPasswordRotator.Service
{
    public class UpdateHostService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly UpdateService _updateService;

        public UpdateHostService(UpdateService heartbeatService)
        {
            _updateService = heartbeatService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(CheckHeartbeat, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;
        }

        private async void CheckHeartbeat(object state)
        {
            Console.WriteLine("Executing heart beat check...");
            await _updateService.CheckHeartbeatAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
