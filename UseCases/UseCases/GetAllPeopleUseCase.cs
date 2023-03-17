using Domain.Interfaces.Repositories;
using Dtos;
using Ports.Input;
using Ports.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.UseCases
{
    public class GetAllPeopleUseCase : IGetAllPeopleInputPort
    {
        private readonly IPersonRepository _repository;
        private readonly IGetAllPeopleOutputPort _outputPort;

        public GetAllPeopleUseCase(IPersonRepository repository, IGetAllPeopleOutputPort outputPort)
        {
            _repository = repository;
            _outputPort = outputPort;
        }

        public async Task GetAllPeopleHandle()
        {
            var people = await _repository.GetAll();

            var peopleView = new List<PersonViewDto>();

            if (people is not null)
            {
                peopleView = people.Select(p => new PersonViewDto()
                {
                    Names = p.Names,
                    LastNames = p.LastNames,
                    Email = p.Email,
                    IdentificationNumber = p.IdentificationNumber,
                    IndentificationType = p.IndentificationType,
                    CreationDate = p.CreationDate
                }).ToList();

            }

            await _outputPort.GetAllPeopleHandle(peopleView);
        }
    }
}
