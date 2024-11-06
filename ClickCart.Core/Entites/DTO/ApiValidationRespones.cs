using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCart.Core.Entites.DTO
{
    public class ApiValidationRespones:ApiRespones
    {
      //  public int StatusCode { get; set; }
      //  public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
      //  public bool IsSuccess { get; set; }

        public ApiValidationRespones(IEnumerable<string> errors=null,int ? statusCode=400) : base(statusCode)
        {
            Errors = errors ?? new List<string>();
        }

    }
}
