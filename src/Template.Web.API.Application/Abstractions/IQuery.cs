using MediatR;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse>
    where TResponse : Result
{
}
