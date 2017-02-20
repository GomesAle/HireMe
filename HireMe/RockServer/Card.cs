using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RockServer
{
    [DataContract]
    class Card
    {
        [DataMember]
        public String cardholderName; //Nome do portador do cartão
        [DataMember]
        public long number; //Os números que são impressos no cartão, podendo variar entre 12 à 19 dígitos
        [DataMember]
        public DateTime expirationDate; //Data de expiração do cartão
        [DataMember]
        public String cardBrand; //Bandeira do cartão
        [DataMember]
        public int password; //Senha do cartão
        [DataMember]
        public string type; //Chip ou tarja magnética
        [DataMember]
        public bool hasPassword; //Se o cartão possui senha.Apenas cartões de tarja magnética podem ter essa propriedade como True
        [DataMember]
        public float limit; //Limite do cartão

        public Card(String cardholderName, long number, DateTime expirationDate,
            String cardBrand, int password, string type, float limit)
        {
            this.cardholderName = cardholderName;
            this.number = number;
            this.expirationDate = expirationDate;
            this.cardBrand = cardBrand;
            this.password = password;
            this.type = type;
            if (type.Equals("chip"))
            {
                this.hasPassword = false;
            }else
            {
                this.hasPassword = true;
            }
            this.limit = limit;
        }
    }
}
