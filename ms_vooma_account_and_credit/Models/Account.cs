using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ms_account_and_credit_card.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public int Iban { get; set; }
        public string BankCode { get; set; }
        public int CustomerId { get; set; }
        public String Status { get; set; }


        public Account()
        {
            MyCards = new HashSet<Card>();
        }

        public virtual ICollection<Card> MyCards { get; set; }
    }
}
