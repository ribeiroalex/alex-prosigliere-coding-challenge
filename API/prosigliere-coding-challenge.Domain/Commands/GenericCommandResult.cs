using prosigliere_coding_challenge.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prosigliere_coding_challenge.Domain.Commands
{
    public sealed record GenericCommandResult : ICommandResult
    {
        public GenericCommandResult()
        {

        }
        public GenericCommandResult(bool sucesss, string message, object data)
        {
            Sucess = sucesss;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }

        public object Data { get; set; }
    }
}
