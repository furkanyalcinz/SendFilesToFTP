using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public string? ResponseCode { get; set; }
        public Result() { }
        public Result(bool? success, string? message) { Success = success; Message = message; }
        public Result(bool? success, string? message, string responseCode)
        {
            Success= success;
            Message = message;
            ResponseCode = responseCode;
        }
    }
}
