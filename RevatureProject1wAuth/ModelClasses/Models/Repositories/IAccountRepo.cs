using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ModelClasses.Models.Repositories
{
    public interface IAccountRepo
    {
        Task<Account> GetAccount(int id);
       
        Task<AccountTypes> GetAccountType(int id);
      
        Task<List<AccountTypes>> GetAccountTypes();

        Task<bool> AddToLoanTable(LoanTable loanTable);
        Task<bool> AddToTermDepositTable(TermDepositTable termTable);
        Task<List<Account>> Get();

        Task<bool> Create(Account account);


        Task<bool> AddTransaction(Transaction transaction);


        Task<List<Transaction>> GetTransactions(int id);

        Task<bool> DeleteAccount(Account account); 
    }
}
