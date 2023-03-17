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
    public class PersonEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/Person/SavePerson", SavePerson)
            .WithName("SavePerson");

            app.MapGet("/api/Person/GetAllPeople", GetAllPeople)
            .WithName("GetAllPeople");
        }

        [AllowAnonymous]
        private static async Task<IResult> SavePerson([FromServices] ISavePersonInputPort inputPort, 
            [FromServices] ISavePersonOutputPort outputPort,
            [FromBody] PersonInputDto person)
        {
            await inputPort.SavePersonHandle(person);
            var response = ((IPresenter<ResponseModel<PersonInputDto>>)outputPort).Content;

            return Results.Ok(response);
        }

        [Authorize]
        private static async Task<IResult> GetAllPeople([FromServices] IGetAllPeopleInputPort inputPort,
            [FromServices] IGetAllPeopleOutputPort outputPort)
        {
            await inputPort.GetAllPeopleHandle();
            var response = ((IPresenter<List<PersonViewDto>>)outputPort).Content;

            return Results.Ok(response);
        }
    }
}
