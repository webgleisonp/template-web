using MediatR;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Abstractions;

public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IQuery<TResponse>
    where TResponse : Result
{
}
