using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace RockServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int porta = 5000;
            const string IP = "127.0.0.1";

            while (true)
            {
                //Começa a escutar o client
                TcpListener listener = new TcpListener(IPAddress.Parse(IP), porta);
                listener.Start();

                //Se liga no client.
                TcpClient client = listener.AcceptTcpClient();

               //Monta o array de bytes de acordo com o que vai vir do client.
                NetworkStream networkStream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];

                //Lê os dados do Stream
                int bytesRead = networkStream.Read(buffer, 0, client.ReceiveBufferSize);

                //Converte para bytes para String
                string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                //Pegar o json recebido, transformar em objeto e fazer as checagens necessárias.
                Card cartao = null;
                Transaction transacao = null;
                string dataSent = "";

                if (dataReceived.Contains("cardholderName"))
                {
                    cartao = (Card)JsonUtil.converterJsonParaObjeto<Card>(dataReceived);
                    if (cartao.cardholderName == "")
                    {
                        //Se estiver vazio, é porque está executando uma transacao
                        //Checa se está no banco.
                        //Se estiver, permite a transacao.
                        DataTable tabela = executarSQL("select * from Card where number = " + cartao.number);

                        if (tabela.Rows.Count > 0)
                        {
                            //Cartão existe
                            dataSent = "Cartão existe";
                            Card c = new Card();
                            c.cardBrand = tabela.Rows[0]["cardBrand"].ToString();
                            c.cardholderName = tabela.Rows[0]["cardholderName"].ToString();
                            c.expirationDate = DateTime.Parse(tabela.Rows[0]["expirationDate"].ToString());
                            if (tabela.Rows[0]["hasPassword"].ToString() == "0")
                            {
                                c.hasPassword = false;
                            }else
                            {
                                c.hasPassword = true;
                            }

                            c.limit = float.Parse(tabela.Rows[0]["limit"].ToString());
                            c.number = long.Parse(tabela.Rows[0]["number"].ToString());
                            c.password = int.Parse(tabela.Rows[0]["password"].ToString());
                            c.type = tabela.Rows[0]["type"].ToString();

                            dataSent = JsonUtil.converterObjetoParaJson(c);
                            Console.WriteLine(dataSent);

                        }
                        else{
                            //Cartão não existe
                            dataSent = "Cartão não existe";
                        }

                    }
                    else
                    {
                        //Se não estiver vazio, é porque está criando o cartão.
                        //Salva o cartão no banco

                        //Converte de boolean para bit
                        byte temSenha = 0;
                        if (cartao.hasPassword)
                        {
                            temSenha = 1;
                        }

                        executarSQL("insert into Card values ('"+cartao.cardholderName+"', "+cartao.number+", '"+cartao.expirationDate.ToString("MM/dd/yyyy")+"', '"+cartao.cardBrand+"', "+cartao.password+", '"+cartao.type+"', "+temSenha+", "+cartao.limit+")");  
                    }
                }
                else
                {
                    if (dataReceived.Contains("amount"))
                    {
                        transacao = (Transaction)JsonUtil.converterJsonParaObjeto<Transaction>(dataReceived);
                        Console.WriteLine(dataReceived);
                        if (transacao.amount <= cartao.limit)
                        {
                            dataSent = "Aprovado";
                            //Transacao efetuada com sucesso.
                            //Salvar no banco de dados
                            //Reenviar a mensagem de sucesso

                            executarSQL("insert into Transacao values("+transacao.amount+", '"+transacao.type+"', "+cartao.number+", "+transacao.number+")");
                        }
                        else
                        {
                            dataSent = "Transação negada";
                        }
                    }
                }    
                    
                //Manda de volta para o client a string dataSent
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(dataSent);
                networkStream.Write(bytesToSend, 0, bytesToSend.Length);

                //Fechar para não ficar recebendo string vazias.
                client.Close();
                listener.Stop();
            }
        }

        //https://msdn.microsoft.com/pt-br/library/fksx3b4f.aspx
        public static DataTable executarSQL(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source=ALEGOMES-PC;Initial Catalog=HireMe;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();

            DataTable tabela = new DataTable();

            tabela.Load(reader);

            sqlConnection.Close();

            return tabela;
        }
    }
}
