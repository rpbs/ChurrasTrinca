using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class BaseResponse
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; } = true;

        public BaseResponse()
        {
        }

        public BaseResponse(string mensagem, bool sucesso)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
        }
    }
}
