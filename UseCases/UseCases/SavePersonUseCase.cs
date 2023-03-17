using Dtos;
using Ports.Input;
using Ports.Output;
using Domain.Common;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public class SavePersonUseCase : ISavePersonInputPort
    {
        private readonly IPersonRepository _personRepository;
        private readonly ISavePersonOutputPort _outputPort;

        public SavePersonUseCase(IPersonRepository personRepository, ISavePersonOutputPort outputPort) 
        {
            _personRepository = personRepository;
            _outputPort = outputPort;
        }

        public async Task SavePersonHandle(PersonInputDto person)
        {
            var personSave = new Person()
            {
                Names = person.Names,
                LastNames = person.LastNames,
                IndentificationType = person.IndentificationType,
                IdentificationNumber = person.IdentificationNumber,
                Email = person.Email,
                FullName = $"{person.Names} {person.LastNames}", 
                FullIdentification = $"{person.IndentificationType} {person.IdentificationNumber}",
                User = new User()
                {
                    Password = person.Password,
                    UserName = person.UserName
                }
            };

            var saved = await _personRepository.SavePerson(personSave);

            if (saved)
            {
                var response = new ResponseModel<PersonInputDto>()
                {
                    IsSuccess = true,
                    Message = "Persona guardada correctamente. ",
                    Result = person
                };

                await _outputPort.SavePersonHandle(response);
            }

        }
    }
}
