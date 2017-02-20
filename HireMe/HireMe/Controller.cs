using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockClient
{
    class Controller
    {
        public String enviarMensagem(String mensagem)
        {
            Program p = new Program();
            return p.enviar(mensagem);
        }
    }
}
