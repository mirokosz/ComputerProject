using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.Application.Computer.Queries.GetComputerByEncodedName
{
    public class GetComputerByEncodedNameQuery : IRequest<ComputerDto>
    {
        public string EncodedName {  get; set; }
        public GetComputerByEncodedNameQuery(string encodedName)
        {
            EncodedName = encodedName;
        }
    }
}
