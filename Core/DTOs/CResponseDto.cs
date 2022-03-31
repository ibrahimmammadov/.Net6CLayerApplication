using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CResponseDto<T>
    {
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CResponseDto<T> Success(int statuscode, T data)
        {
            return new CResponseDto<T> { StatusCode = statuscode, Data = data };
        }
        public static CResponseDto<T> Success(int statuscode)
        {
            return new CResponseDto<T>{ StatusCode = statuscode};
        }
        public static CResponseDto<T> Fail(int statuscode, List<string> errors)
        {
            return new CResponseDto<T>{ StatusCode = statuscode, Errors = errors };
        }
        public static CResponseDto<T> Fail(int statuscode, string error)
        {
            return new CResponseDto<T> { StatusCode = statuscode, Errors = new List<string> { error } };
        }
        
    }
}
