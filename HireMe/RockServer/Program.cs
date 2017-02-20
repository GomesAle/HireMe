using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RockServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PORT_NO = 5000;
            const string SERVER_IP = "127.0.0.1";

            

            while (true)
            {
                //---listen at the specified IP and port no.---
                IPAddress localAdd = IPAddress.Parse(SERVER_IP);
                TcpListener listener = new TcpListener(localAdd, PORT_NO);

                listener.Start();

                //---incoming client connected---
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Ouvindo");
                //---get the incoming data through a network stream---
                NetworkStream nwStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //---read incoming stream---
                int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

                //---convert the data received into a string---
                string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);

                //Pegar o json recebido, transformar em objeto e fazer as checagens necessárias.
                Card cartao = null;
                Transaction transacao = null;
                string dataSent = "xxx";

                if (dataReceived.Contains("cardholderName"))
                {
                    Console.WriteLine("Contem");
                    cartao = (Card)JsonUtil.converterJsonParaObjeto<Card>(dataReceived);
                    Console.WriteLine(dataReceived);
                    if (cartao.cardholderName == "")
                    {
                        Console.WriteLine("cardholder é vazio");
                        //Se estiver vazio, é porque está executando uma transacao
                        //Checa se está no banco.
                        //Se estiver, permite a transacao.

                        //Se não estiver retorna erro. Cartão não encontrado.
                        //Se a senha estiver errada. Retorna erro de senha.
                    }
                    else
                    {
                        dataSent = "volta";
                        //Se não estiver vazio, é porque está criando o cartão.
                        //Salva o cartão no banco
                    }
                }
                else
                {
                    if (dataReceived.Contains("amount"))
                    {
                        Console.WriteLine("Dado enviado que entra no transaction: " + dataReceived);
                        transacao = (Transaction)JsonUtil.converterJsonParaObjeto<Transaction>(dataReceived);
                        Console.WriteLine(dataReceived);
                        if (transacao.amount <= cartao.limit)
                        {
                            //Transacao efetuada com sucesso.
                            //Salvar no banco de dados
                            //Reenviar a mensagem de sucesso
                        }
                        else
                        {
                            //Valor fora do limite
                        }
                    }
                }    
                    

                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(dataSent);
                nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                client.Close();
                listener.Stop();
            }


        }
    }
}
