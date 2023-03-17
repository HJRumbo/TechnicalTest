using Dtos;
using Ports.Input;
using Ports.Output;
using Carter;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Presenters.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Endpoints
{
    public class AuthEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/Auth/Login", Login)
            .WithName("Login");
        }

        [AllowAnonymous]
        private static async Task<IResult> Login([FromServices] ILoginInputPort inputPort,
            [FromServices] ILoginOutputPort outputPort,
            [FromBody] LoginInputDto login)
        {
            await inputPort.LoginHandle(login);
            var response = ((IPresenter<ResponseModel<LoginViewDto>>)outputPort).Content;

            return Results.Ok(response);
        }
    }
}
