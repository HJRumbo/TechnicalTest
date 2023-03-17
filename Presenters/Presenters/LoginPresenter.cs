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
    public class LoginPresenter : ILoginOutputPort, IPresenter<ResponseModel<LoginViewDto>>
    {
        public ResponseModel<LoginViewDto>? Content { get; set; }

        public Task LoginHandle(ResponseModel<LoginViewDto> response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
