using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites
{
    public class ApiRespones
    {
        public int? StatusCode {get; set;}
        public bool IsSucccess { get; set; }

        public string? Message { get; set; }
        public object? Result { get; set; }
        public ApiRespones(int? statuscode=null,string? message=null,object? result=null)
        {
            StatusCode = statuscode;
            Message = message ?? GetMessageForStatusCode(statuscode);
            Result = result;
            IsSucccess = statuscode >= 200 && statuscode <= 300;


        }
         private string? GetMessageForStatusCode(int? statuscode)
        {
            return statuscode switch
            {
                200=>"Sucessfully",
                201=> "Created Sucessfully",
                400 =>"Bad Request",
                404=>"Not Found",
                500=>"Internal Server Error",
                     _ =>null//واحد مش من هدول 
            };
        }
    }
}
