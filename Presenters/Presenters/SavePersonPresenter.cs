using Dtos;
using Ports.Output;
using Domain.Common;
using Presenters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenters.Presenters
{
    public class SavePersonPresenter : ISavePersonOutputPort, IPresenter<ResponseModel<PersonInputDto>>
    {
        public ResponseModel<PersonInputDto>? Content { get; set; }

        public Task SavePersonHandle(ResponseModel<PersonInputDto> person)
        {
            Content = person;
            return Task.CompletedTask;
        }
    }
}
