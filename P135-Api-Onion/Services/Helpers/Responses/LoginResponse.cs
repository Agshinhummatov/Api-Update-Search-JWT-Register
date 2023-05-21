using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers.Responses
{
    public class LoginResponse
    {
        public string StatusMessage { get; set; }
        public List<string> Erros { get; set; }
        public string Token { get; set; }
    }
}
