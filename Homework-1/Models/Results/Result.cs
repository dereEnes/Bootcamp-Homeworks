using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkOne.Models.Results
{
    public class Result:IResult
    {
        public bool? Success { get; set; }
        public bool? Error { get; set; }
        public string Data { get; set; } = string.Empty;
        
    }
}
