﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMe
{
    class Transaction
    {
        Decimal amount; //Valor da transação
        String type; //Tipo da transação
        Card card; //Propriedades do cartão
        int number; //Número de parcelas, se for uma transação de crédito parcelado

        public Transaction(Decimal amount, String type, 
            Card card, int number)
        {
            this.amount = amount;
            this.type = type;
            this.card = card;
            this.number = number;
        }
    }
}