using Microsoft.AspNetCore.Routing;

namespace Template.Web.API.Presentation.MapEndpoints.Abstractions;

internal interface IEndpointMap
{
    void MapEndpoints(IEndpointRouteBuilder app);
}
