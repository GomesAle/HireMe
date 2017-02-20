using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RockServer
{
    [DataContract]
    class Transaction
    {
        [DataMember]
        public float amount; //Valor da transação

        [DataMember]
        public String type; //Tipo da transação

        [DataMember]
        public Card card; //Propriedades do cartão

        [DataMember]
        public int number; //Número de parcelas, se for uma transação de crédito parcelado

        public Transaction(float amount, String type, 
            Card card, int number)
        {
            this.amount = amount;
            this.type = type;
            this.card = card;
            this.number = number;
        }
    }
}
