using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkOne.Models.Results
{
    public interface IResult
    {
         bool? Success { get; set; }
         bool? Error { get; set; }
         string Data { get; set; }
    }
}
