using MediatR;
using Microsoft.Extensions.Logging;
using Template.Web.API.Application.Abstractions;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result
{
    public readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Antes da execução do handle
        _logger.LogInformation($"Inicio execução {typeof(TRequest).Name}");

        var result = await next();

        //depois da execução do handle
        if (!result.IsSuccess && result.Error is not null)
        {
            _logger.LogError($"Exception occurred: {result.Error.Description}", result.Error);
        }

        if (request is IQuery<TResponse>) _logger.LogInformation(result.ToString());

        _logger.LogInformation($"Final execução {typeof(TRequest).Name}");

        return result;
    }
}
