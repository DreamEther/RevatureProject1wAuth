using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelClasses.Models;
using ModelClasses.View_Models;
using RevatureProject1wAuth.Data;

namespace RevatureProject1wAuth.Controllers
{
    public class CheckingAccountController : Controller
    {
        private readonly MyDbContext _context;
        ApplicationDbContext listOfUsers = new ApplicationDbContext();

        public CheckingAccountController(MyDbContext context)
        {
            _context = context;
        }

        // GET: CheckingAccount
        public async Task<IActionResult> Index(int id)
        {
            var list = _context.CheckingAccounts.Where(x => x.CustomerID == User.Identity.GetUserId());
           
            return View(await list.ToListAsync());
        }

        // GET: CheckingAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingAccount = await _context.CheckingAccounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (checkingAccount == null)
            {
                return NotFound();
            }

            return View(checkingAccount);
        }

        // GET: CheckingAccount/Create
      

        // POST: CheckingAccount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CheckingAccount checking = new CheckingAccount();
            checking.CustomerID = User.Identity.GetUserId();     
            _context.Add(checking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //[HttpGet]
        //public IActionResult Deposit()
        //{
            
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Deposit(int id, Deposit deposit)
        //{
        //    var getAccount = _context.CheckingAccounts.FirstOrDefault(x => x.ID == id);
        //    getAccount.Balance += deposit.DepositAmount;
        //    decimal newBalance = getAccount.Balance;
        //    decimal newDeposit = deposit.DepositAmount;
        //    string depositString = newDeposit.ToString();
        //    string appendSymbol = "+$" + depositString;
        //    Transaction newTransaction = new Transaction(id, newBalance, appendSymbol, DateTime.Now, "Deposit");
        //    _context.Update(getAccount);
        //    _context.Add(newTransaction);
        //    await _context.SaveChangesAsync();


        //    //  account.Balance += checkingAccount.Balance;
        //    return RedirectToAction(nameof(Index));
        //}

        [HttpGet]
        public IActionResult MakeATransfer(int id)
        {
            //var account = _context
            var accounts = _context.Accounts.ToList();
           // Transfer transfer = new Transfer();
           Transfer transfer = new Transfer { accounts = accounts };
           // transfer.accounts.AddRange(accounts);
            return View("MakeATransfer", transfer);
        }

       
        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Withdraw(int id, Withdraw withdraw)
        //{
        //    var getAccount = _context.CheckingAccounts.FirstOrDefault(x => x.ID == id);
        //    getAccount.Balance -= withdraw.WithdrawalAmount;
        //    decimal newBalance = getAccount.Balance;
        //    if (getAccount.Balance <= 0)
        //    {
        //        ViewBag.Error = "Cannot withdraw more than is in your account";
        //        return View();
        //    }
        //    decimal newWithdrawal = withdraw.WithdrawalAmount;
        //    string withdrawalString = newWithdrawal.ToString();
        //    string appendSymbol = "-$" + withdrawalString;
        //    Transaction newTransaction = new Transaction(id, newBalance, appendSymbol, DateTime.Now, "Withdrawal");
        //    _context.Update(getAccount);
        //    _context.Add(newTransaction);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public IActionResult ListOfTransactions(int id)
        //{
        //    var getTransactions = _context.Transactions.Where(x => x.AccountID == id).ToList();

        //    return View(getTransactions);

        //}


        // GET: CheckingAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingAccount = await _context.CheckingAccounts.FindAsync(id);
            if (checkingAccount == null)
            {
                return NotFound();
            }
            return View(checkingAccount);
        }

        // POST: CheckingAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountType,CustomerID,ID,Balance")] CheckingAccount checkingAccount)
        {
            if (id != checkingAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkingAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckingAccountExists(checkingAccount.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(checkingAccount);
        }

        // GET: CheckingAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkingAccount = await _context.CheckingAccounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (checkingAccount == null)
            {
                return NotFound();
            }

            return View(checkingAccount);
        }

        // POST: CheckingAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkingAccount = await _context.CheckingAccounts.FindAsync(id);
            _context.CheckingAccounts.Remove(checkingAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckingAccountExists(int id)
        {
            return _context.CheckingAccounts.Any(e => e.ID == id);
        }
    }
}
