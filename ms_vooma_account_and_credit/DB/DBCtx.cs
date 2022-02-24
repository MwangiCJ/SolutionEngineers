using ms_account_and_credit_card.Models;

using Microsoft.EntityFrameworkCore;
namespace ms_account_and_credit_card.DB
{
    public class DBCtx : DbContext
    {
        public DBCtx(DbContextOptions<DBCtx> options) : base(options)
        {

        }


        public virtual DbSet<Account> accounts { get; set; }
        public virtual DbSet<Card> cards { get; set; }


    }
}