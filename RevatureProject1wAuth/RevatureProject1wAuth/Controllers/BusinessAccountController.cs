using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelClasses.Models;
using ModelClasses.View_Models;

namespace RevatureProject1wAuth.Controllers
{
    public class BusinessAccountController : Controller
    {
        private readonly MyDbContext _context;

        public BusinessAccountController(MyDbContext context)
        {
            _context = context;
        }

        // GET: BusinessAccount
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusinessAccounts.ToListAsync());
        }

        // GET: BusinessAccount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAccount = await _context.BusinessAccounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (businessAccount == null)
            {
                return NotFound();
            }

            return View(businessAccount);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            BusinessAccount businessAccount = new BusinessAccount();
            businessAccount.CustomerID = User.Identity.GetUserId();
            //List<CheckingAccount> list = new List<CheckingAccount>();
            //var currentCustomer = listOfUsers.Users.Where(x => x.Id == checking.CustomerID);
            //var currentCustomer = CustomerController.customers.FirstOrDefault(x => x.UserID == User.Identity.GetUserId());
            //currentCustomer.Accounts.Add(checking);
            _context.Add(businessAccount);
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
        //    var getAccount = _context.BusinessAccounts.FirstOrDefault(x => x.ID == id);
        //    if (deposit.DepositAmount <= 0)
        //    {
        //        ViewBag.Error = "Amount must be greaters than 0";
        //        return View();
        //    }
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

        public IActionResult Transfer(int id)
        {
            return View("MakeATransfer");
        }
        //[HttpGet]
        //public IActionResult Withdraw()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Withdraw(int id, Withdraw withdraw)
        //{
        //    var getAccount = _context.BusinessAccounts.FirstOrDefault(x => x.ID == id);
        //    getAccount.Balance -= withdraw.WithdrawalAmount;
        //    decimal newBalance = getAccount.Balance;
        //    if (newBalance < 0)
        //    {
        //        newBalance += (newBalance * getAccount.InterestRate) / 100;
        //        ViewBag.Message = "Since your balance has fallen below 0, an overdraft fee will be applied to your balance";
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

        // GET: BusinessAccount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAccount = await _context.BusinessAccounts.FindAsync(id);
            if (businessAccount == null)
            {
                return NotFound();
            }
            return View(businessAccount);
        }

        // POST: BusinessAccount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AccountType,CustomerID,Balance,InterestRate")] BusinessAccount businessAccount)
        {
            if (id != businessAccount.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessAccountExists(businessAccount.ID))
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
            return View(businessAccount);
        }

        // GET: BusinessAccount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessAccount = await _context.BusinessAccounts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (businessAccount == null)
            {
                return NotFound();
            }

            return View(businessAccount);
        }

        // POST: BusinessAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessAccount = await _context.BusinessAccounts.FindAsync(id);
            _context.BusinessAccounts.Remove(businessAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessAccountExists(int id)
        {
            return _context.BusinessAccounts.Any(e => e.ID == id);
        }
    }
}
