using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace FizzBuzzAPI.Models
{
    public class ApiResponse<T> where T : class
    {
        public ApiResponse(T data , int code, string errorMessage = default)
        {
            ErrorMessage = errorMessage;
            StatusCode = code;
            HasError = string.IsNullOrEmpty(errorMessage) ? false : true;
            Data = HasError ? null : data;
        }
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}