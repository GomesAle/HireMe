using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RockClient
{
    class Program
    {
        int porta = 5000;
        const string IP = "127.0.0.1";

        public String enviar(String mensagem)
        {
            //Criar o client no ip e porta especificados.
            TcpClient client = new TcpClient(IP, porta);

            //Pega o vetor de bytes da mensagem para enviar pela rede.
            NetworkStream networkStream = client.GetStream();
            string textToSend = mensagem.Trim();
            byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);

            //manda pela rede
            networkStream.Write(bytesToSend, 0, bytesToSend.Length);

            //Pega os dados enviados pelo servidor
            byte[] bytesToRead = new byte[client.ReceiveBufferSize];
            int bytesRead = networkStream.Read(bytesToRead, 0, client.ReceiveBufferSize);

            client.Close();

            return Encoding.ASCII.GetString(bytesToRead, 0, bytesRead);
        }
    }
}
