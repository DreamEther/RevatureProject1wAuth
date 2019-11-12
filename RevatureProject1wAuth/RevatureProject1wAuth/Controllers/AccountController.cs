using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelClasses.Models;
using ModelClasses.Models.Repositories;
using ModelClasses.View_Models;
using RevatureProject1wAuth.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevatureProject1wAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo _repo;
        //private readonly AccountTypesRepo _accountTypesRepo;
        public AccountController(IAccountRepo repo)
        {
            _repo = repo;
           // _accountTypesRepo = accountTypesRepo;
        }

        public async Task<IActionResult> Index(string? message)
        {
            var accounts = await _repo.Get();
            var myAccounts = accounts.Where(x => x.CustomerID == User.Identity.GetUserId());
            ViewBag.WithdrawalError = message;
            return View(myAccounts);
        }
     

        [HttpGet]
        public async Task<IActionResult> ListOfTransactions(int id)
        {
            var transactions = await _repo.GetTransactions(id);
            SearchTransactions searchTransactions = new SearchTransactions();
            searchTransactions.Transactions = transactions;
            return View(searchTransactions);
        }

        [HttpPost]
        public async Task<IActionResult> ListOfTransactions(int id, SearchTransactions model)
        {
            if (model.StartDate > model.EndDate)
            {
                return NotFound();
            }
            var transactions = await _repo.GetTransactions(id);
            List<Transaction> narrowedList = new List<Transaction>();

           for(int i = 0; i < transactions.Count - 1; i++) // needed the -1 to account for list index. Otherwise list is empty
            {
                if(transactions[i].DateTime >= model.StartDate && transactions[i].DateTime <= model.EndDate)
                {     
                        narrowedList.Add(transactions[i]);
                }
            }
        
            return View("TransactionSearch", narrowedList);
        }
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View("CreateAccount");
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var accountTypes = await _repo.GetAccountTypes();
            if (id == 1)
            {
                var checkingAccountMaster = accountTypes.FirstOrDefault(x => x.AccountType == "Checking");
                CheckingAccount checking = new CheckingAccount()
                {
                    DateTime = DateTime.Now,
                    AccountType = checkingAccountMaster,
                    CustomerID = User.Identity.GetUserId()
                };
              
                //checking.AccountType.InterestRate = checkingAccountMaster.InterestRate;
                checking.InterestRate = checkingAccountMaster.InterestRate;
                await _repo.Create(checking);
                return RedirectToAction(nameof(Index));
            }
           
            else if (id == 2)
            {
                var businessAccountMaster = accountTypes.FirstOrDefault(x => x.AccountType == "Business");
                BusinessAccount businessAccount = new BusinessAccount()
                {
                    DateTime = DateTime.Now,
                    AccountType = businessAccountMaster,
                    CustomerID = User.Identity.GetUserId()
                };
                businessAccount.InterestRate = businessAccountMaster.InterestRate;
                await _repo.Create(businessAccount);
                return RedirectToAction(nameof(Index));
            }
            else if (id == 3)
            {
                return RedirectToAction(nameof(TakeOutALoan));          
            }
            else if (id == 4)
            {
                return RedirectToAction(nameof(CreateTermDeposit));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult CreateTermDeposit()
        {
            CreateCD cd = new CreateCD();
            cd.StartDate = DateTime.Now;
            return View("CreateTermDeposit");
        }


        [HttpPost]
        public async Task<IActionResult> CreateTermDeposit(CreateCD model)       
        {
            if (model.DepositAmount <= 0)
            {
                ViewBag.DepositError = "Loan must be greater than zero";
                return View();
            }
            else
            {
                TermDepositTable termDepositTable = new TermDepositTable()
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
                var accountTypes = await _repo.GetAccountTypes();
                var termDepositAccountMaster = accountTypes.FirstOrDefault(x => x.AccountType == "Term Deposit");
                TermDeposit term = new TermDeposit()
                {
                    DateTime = DateTime.Now,
                    AccountType = termDepositAccountMaster,
                    CustomerID = User.Identity.GetUserId()
                };
                term.Balance += model.DepositAmount;
                term.InterestRate = termDepositAccountMaster.InterestRate;
                await _repo.Create(term);
                var accounts = await _repo.Get();
                var newCD = accounts.Last();
                termDepositTable.AccountID = newCD.ID;
                await _repo.AddToTermDepositTable(termDepositTable);

                return RedirectToAction(nameof(Index));


            }
        }
        [HttpGet]
        public ActionResult TakeOutALoan()
        {
            return View("CreateLoan");
        }
        //the partial view, i pass it that model as a list
        [HttpPost]
        public async Task<IActionResult> TakeOutALoan(TakeOutALoan model)
        {
            if (model.LoanAmount <= 0)
            {
                ViewBag.DepositError = "Loan must be greater than zero";
                return View();
            }
            else
            {
                LoanTable loanTable = new LoanTable()
                {                
                    AmountDuePerMonth = (model.LoanAmount / model.MonthlyPlan),
                    MonthlyPlan = model.MonthlyPlan
                };
                var accountTypes = await _repo.GetAccountTypes();
                var loanAccountMaster = accountTypes.FirstOrDefault(x => x.AccountType == "Loan");
                Loan loan = new Loan()
                {
                    DateTime = DateTime.Now,
                    AccountType = loanAccountMaster,
                    CustomerID = User.Identity.GetUserId()
                };
                loan.InterestRate = loanAccountMaster.InterestRate;
                var interest = (model.LoanAmount * loanAccountMaster.InterestRate) / 100;
                loan.Balance = model.LoanAmount + interest;
                await _repo.Create(loan);
                var accounts = await _repo.Get();
                var newLoan = accounts.Last();
                loanTable.AccountID = newLoan.ID;

                await _repo.AddToLoanTable(loanTable);
                return RedirectToAction(nameof(Index));
            }
           
        }

        [HttpGet]
        public IActionResult Deposit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Deposit(int id, Deposit deposit)
        {
            var getAccount = await _repo.GetAccount(id);
            if (deposit.DepositAmount < 0)
            {
                ViewBag.DepositError = "Deposit must be greater than zero";
                return View();
            }
            if (getAccount.AccountTypeAsString == "Loan")
            {
                getAccount.Balance -= deposit.DepositAmount;
                string depositString = deposit.DepositAmount.ToString();
                string appendSymbol = "+$" + depositString;
                Transaction newTransaction = new Transaction(id, getAccount.Balance, appendSymbol, DateTime.Now, "Loan Payment");
                await _repo.AddTransaction(newTransaction);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                getAccount.Balance += deposit.DepositAmount;
                string depositString = deposit.DepositAmount.ToString();
                string appendSymbol = "+$" + depositString;
                Transaction newTransaction = new Transaction(id, getAccount.Balance, appendSymbol, DateTime.Now, "Deposit");
                await _repo.AddTransaction(newTransaction);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(int id, Withdraw withdraw)
        {
            var getAccount = await _repo.GetAccount(id);

            if (getAccount.AccountTypeAsString == "Checking")
            {
                var newBalance = getAccount.Balance - withdraw.WithdrawalAmount;
                CheckingAccountBL checkingBL = new CheckingAccountBL();
                if (withdraw.WithdrawalAmount <= 0)
                {
                    ViewBag.WithdrawalError = "Withdrawal must be greater than zero";
                    ViewBag.IsEnabled = true;
                    return View();
                }
                else if (withdraw.WithdrawalAmount > 0 && newBalance < 0)
                {
                    ViewBag.WithdrawalError = "You do not have enough funds in your account for this withdrawal!";
                    ViewBag.IsEnabled = true;
                    return View();
                }
                else
                {
                    getAccount.Balance = checkingBL.Withdraw(getAccount.Balance, withdraw.WithdrawalAmount, getAccount.InterestRate);
                    var withAsString = checkingBL.WithdrawalAsString(withdraw.WithdrawalAmount);
                    Transaction newTransaction = new Transaction(id, getAccount.Balance, withAsString, DateTime.Now, "Withdrawal");
                    await _repo.AddTransaction(newTransaction);

                    return RedirectToAction(nameof(Index));
                }
            }
            if (getAccount.AccountTypeAsString == "Business")
            {
                BusinessAccountBL busBL = new BusinessAccountBL();
                if (withdraw.WithdrawalAmount <= 0)
                {
                    ViewBag.WithdrawalError = "Withdrawal must be greater than zero";
                    return View();
                }
                else if (withdraw.WithdrawalAmount > 0 && getAccount.Balance == 0)
                {
                    ViewBag.WithdrawalError = "Your balance is below zero! An overdraft fee had been applied to your Balance.";
                  
                    getAccount.Balance = busBL.Withdraw(getAccount.Balance, withdraw.WithdrawalAmount, getAccount.InterestRate);
                    var withdrawalString = busBL.WithdrawalAsString(withdraw.WithdrawalAmount);
                    Transaction newTransaction = new Transaction(id, getAccount.Balance, withdrawalString, DateTime.Now, "Withdrawal");
                    await _repo.AddTransaction(newTransaction);
                    ViewBag.IsEnabled = true;
                    return View();
                  
                }
                else
                {
                    getAccount.Balance = busBL.Withdraw(getAccount.Balance, withdraw.WithdrawalAmount, getAccount.InterestRate);
                    var withdrawalString = busBL.WithdrawalAsString(withdraw.WithdrawalAmount);
                    Transaction newTransaction = new Transaction(id, getAccount.Balance, withdrawalString, DateTime.Now, "Deposit");
                    await _repo.AddTransaction(newTransaction);
                    return RedirectToAction(nameof(Index));
                }
            }
            if (getAccount.AccountTypeAsString == "Term Deposit")
            {
                if (withdraw.WithdrawalAmount != getAccount.Balance)
                {
                    ViewBag.WithdrawalError = "You must withdraw the full amount of your term deposit";
                    ViewBag.IsEnabled = true;
                    return View();
                }
                else
                {
                    return NotFound();
                }

            }
            return NotFound();

        }

        [HttpGet]
        public async Task<IActionResult> MakeATransfer(int id)
            {
            var accounts = await _repo.Get();
            var checkingAccounts = accounts.Where(x => x.AccountTypesID == 1).ToList();
            var businessAccounts = accounts.Where(x => x.AccountTypesID == 2).ToList();
            var loanAccounts = accounts.Where(x => x.AccountTypesID == 3).ToList();
            List<Account> eligibleAccounts = new List<Account>();
            eligibleAccounts.AddRange(checkingAccounts);
            eligibleAccounts.AddRange(businessAccounts);
            eligibleAccounts.AddRange(loanAccounts);
            Transfer transfer = new Transfer { accounts = eligibleAccounts, TransferFrom = id };
            var accountToRemove = transfer.accounts.FirstOrDefault(m => m.ID == id);     
            transfer.accounts.Remove(accountToRemove);
            return View("MakeATransfer", transfer);
            }

        [HttpPost]
        public async Task<IActionResult> MakeATransfer(int id, Transfer transfer)
        {
            var accountFrom = await _repo.GetAccount(id);
            
            var accountTo = await _repo.GetAccount(transfer.TransferTo);
            if (accountTo == null)
            {
                return NotFound();
            }
            var accountFromBalance = accountFrom.Balance - transfer.TransferAmount;
            if(accountFromBalance < 0)
            {
                ViewBag.TransferError = "You do not have enough funds to make this transfer";
                //ViewBag.IsEnabled = true;
                var accounts = await _repo.Get();
                var checkingAccounts = accounts.Where(x => x.AccountTypesID == 1).ToList();
                var businessAccounts = accounts.Where(x => x.AccountTypesID == 2).ToList();
                var loanAccounts = accounts.Where(x => x.AccountTypesID == 3).ToList();
                List<Account> eligibleAccounts = new List<Account>();
                eligibleAccounts.AddRange(checkingAccounts);
                eligibleAccounts.AddRange(businessAccounts);
                eligibleAccounts.AddRange(loanAccounts);
                Transfer transfers = new Transfer { accounts = eligibleAccounts, TransferFrom = id };
                var accountToRemove = transfer.accounts.FirstOrDefault(m => m.ID == id);
                transfer.accounts.Remove(accountToRemove);

                return View(transfers);
            }
            else 
            {
                CheckingAccountBL checkingBL = new CheckingAccountBL();
                accountFrom.Balance = accountFrom.Balance - transfer.TransferAmount;
                var withAsString = checkingBL.WithdrawalAsString(transfer.TransferAmount); // need to change
                Transaction transferFromTransaction = new Transaction(id, accountFrom.Balance, withAsString, DateTime.Now, "Transfer");
                if(accountTo.AccountTypeAsString == "Loan")
                {
                    accountTo.Balance = accountTo.Balance - transfer.TransferAmount;
                    var depAsString = checkingBL.DepositAsString(transfer.TransferAmount); // need to change
                    Transaction TransferToTransaction = new Transaction(id, accountFrom.Balance, withAsString, DateTime.Now, "Transfer");
                    await _repo.AddTransaction(transferFromTransaction);
                    await _repo.AddTransaction(TransferToTransaction);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    accountTo.Balance = accountTo.Balance + transfer.TransferAmount;
                    var depAsString = checkingBL.DepositAsString(transfer.TransferAmount); // need to change
                    Transaction TransferToTransaction = new Transaction(id, accountFrom.Balance, withAsString, DateTime.Now, "Transfer");
                    await _repo.AddTransaction(transferFromTransaction);
                    await _repo.AddTransaction(TransferToTransaction);
                    return RedirectToAction(nameof(Index));
                }
          

            }
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _repo.GetAccount(id);
                
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _repo.GetAccount(id);
            if(account.Balance > 0)
            {
                ViewBag.Error = "You cannot close an account that still has money in it.";
                return View();
            }
            account.IsClosed = true;
            await _repo.DeleteAccount(account);
            return RedirectToAction(nameof(Index));
        }

        //private bool AccountExists(int id)
        //{
        //    return _context.Accounts.Any(e => e.ID == id);
        //}
    }
}
