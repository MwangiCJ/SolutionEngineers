using System;
using System.ComponentModel.DataAnnotations;

namespace ms_account_and_credit_card.Models
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string CardAlias { get; set; }
        public int AccountId { get; set; }
        public String CardType { get; set; } //virtual or physical. Not editable
    }
}
