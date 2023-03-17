using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ports.Input
{
    public interface ISavePersonInputPort
    {
        Task SavePersonHandle(PersonInputDto person);
    }
}
