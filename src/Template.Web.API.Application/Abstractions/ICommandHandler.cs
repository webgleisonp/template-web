using MediatR;
using Template.Web.API.Domain.Shared;

namespace Template.Web.API.Application.Abstractions;

public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : ICommand
{
}
