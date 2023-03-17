using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ports.Output
{
    public interface IGetAllPeopleOutputPort
    {
        Task GetAllPeopleHandle(List<PersonViewDto> people);
    }
}
