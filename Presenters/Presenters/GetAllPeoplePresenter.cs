using Dtos;
using Ports.Output;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Presenters
{
    public class GetAllPeoplePresenter : IGetAllPeopleOutputPort, IPresenter<List<PersonViewDto>>
    {
        public List<PersonViewDto>? Content { get; set; }

        public Task GetAllPeopleHandle(List<PersonViewDto> people)
        {
            Content = people;
            return Task.CompletedTask;  
        }
    }
}
