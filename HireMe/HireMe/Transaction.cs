using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RockClient
{
    [DataContract]
    class Transaction
    {
        [DataMember]
        float amount;  //Valor da transação

        [DataMember]
        String type;  //Tipo da transação

        [DataMember]
        Card card;  //Propriedades do cartão

        [DataMember]
        int number; //Número de parcelas, se for uma transação de crédito parcelado

        public float Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        internal Card Card
        {
            get
            {
                return card;
            }

            set
            {
                card = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
            }
        }

        public Transaction(float amount, String type, 
            Card card, int number)
        {
            this.Amount = amount;
            this.Type = type;
            this.Card = card;
            this.Number = number;
        }
    }
}
