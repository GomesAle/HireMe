using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockClient
{
    class Card
    {
        String cardholderName; //Nome do portador do cartão
        long number; //Os números que são impressos no cartão, podendo variar entre 12 à 19 dígitos
        DateTime expirationDate; //Data de expiração do cartão
        String cardBrand; //Bandeira do cartão
        int password; //Senha do cartão
        string type; //Chip ou tarja magnética
        bool hasPassword; //Se o cartão possui senha.Apenas cartões de tarja magnética podem ter essa propriedade como True
        float limit; //Limite do cartão

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
