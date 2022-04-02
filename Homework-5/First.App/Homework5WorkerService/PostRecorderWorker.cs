using First.App.Business.Abstract;
using First.App.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework5WorkerService
{
    public class PostRecorderWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IQueue<Post> _postQueue;
        private readonly ILogger<PostRecorderWorker> _logger;

        public PostRecorderWorker(IServiceScopeFactory serviceScopeFactory, IQueue<Post> postQueue, ILogger<PostRecorderWorker> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _postQueue = postQueue;
            _logger = logger;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("{Type} is now running in the background.", nameof(PostRecorderWorker));
            await BackgroundProcessing(stoppingToken);
        }
        private async Task BackgroundProcessing(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(200, stoppingToken);
                var post = _postQueue.Dequeue();
                if (post is null) continue;
                _logger.LogInformation("Trying to add a post to database");
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var postService = scope.ServiceProvider.GetRequiredService<IPostService>();
                    postService.Add(post);
                }
            }
        }
    }
}
