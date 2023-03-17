using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }
    }
}
