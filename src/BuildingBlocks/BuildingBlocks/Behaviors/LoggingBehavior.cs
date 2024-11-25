﻿using System.Diagnostics;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("[START] handler Request={Request} - response={Response} - RequestData={RequestData}",
                typeof(TRequest).Name, typeof(TResponse).Name, request   
            );

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            var timeTaken = timer.Elapsed;
            if (timeTaken.Seconds > 3)
                logger.LogWarning("[PERFORMANCE] the request {Request} took {TimeTaken} seconds.",
                    typeof(TRequest).Name, timeTaken.Seconds);

            logger.LogInformation("[END] handler {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);

            return response;
        }
    }
}
