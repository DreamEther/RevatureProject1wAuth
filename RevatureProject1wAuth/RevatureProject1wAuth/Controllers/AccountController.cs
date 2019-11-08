using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModelClasses.Models;
using ModelClasses.Models.Repositories;
using ModelClasses.View_Models;
using RevatureProject1wAuth.BusinessLayer;

namespace RevatureProject1wAuth.Controllers
{
    public class AccountController : Controller
    {
        private readonly BACARepo _repo;

        public AccountController(BACARepo repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repo.Get());
        }

        [HttpGet]
        public async Task<IActionResult> ListOfTransactions(Transaction transaction)
        {
            return View(await _repo.GetTransactions(transaction));
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

            if (getAccount.AccountType == "Checking")
            {
                CheckingAccountBL checkingBL = new CheckingAccountBL();      
                if (withdraw.WithdrawalAmount <= 0)
                {
                    ViewBag.WithdrawalError = "Withdrawal must be greater than zero";
                    return View();
                }
                else if (withdraw.WithdrawalAmount > 0 && getAccount.Balance < 0)
                {
                    ViewBag.WithdrawalError = "You do not have enough funds in your account for this withdrawal!";
                    return View();
                }
                else
                {
                    var newBalance = checkingBL.Withdraw(getAccount.Balance, withdraw.WithdrawalAmount);
                    var withAsString = checkingBL.WithdrawalAsString(withdraw.WithdrawalAmount);
                    //getAccount.Balance -= withdraw.WithdrawalAmount;
                    //string withdrawalString = withdraw.WithdrawalAmount.ToString();
                    //string appendSymbol = "+$" + withdrawalString;
                    Transaction newTransaction = new Transaction(id, getAccount.Balance, withAsString, DateTime.Now, "Withdrawal");
                    await _repo.AddTransaction(newTransaction);
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            if (getAccount.AccountType == "Business")
            {
                BusinessAccountBL busBL = new BusinessAccountBL();
                if (withdraw.WithdrawalAmount <= 0)
                {
                    ViewBag.WithdrawalError = "Withdrawal must be greater than zero";
                    return View();
                }
                else if (withdraw.WithdrawalAmount > 0 && getAccount.Balance < 0)
                {
                    ViewBag.WithdrawalError = "Your balance is below zero! An overdraft fee had been applied to your Balance.";
                    getAccount.Balance = busBL.Withdraw(getAccount.Balance, withdraw.WithdrawalAmount);
                    var withdrawalString = busBL.WithdrawalAsString(withdraw.WithdrawalAmount);
                    //getAccount.Balance -= withdraw.WithdrawalAmount;
                    //string withdrawalString = withdraw.WithdrawalAmount.ToString();
                    //string appendSymbol = "+$" + withdrawalString;
                    Transaction newTransaction = new Transaction(id, getAccount.Balance, withdrawalString, DateTime.Now, "Deposit");
                    await _repo.AddTransaction(newTransaction);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    getAccount.Balance = busBL.Withdraw(getAccount.Balance, withdraw.WithdrawalAmount);
                    var withdrawalString = busBL.WithdrawalAsString(withdraw.WithdrawalAmount);
                    Transaction newTransaction = new Transaction(id, getAccount.Balance, withdrawalString, DateTime.Now, "Deposit");
                    await _repo.AddTransaction(newTransaction);
                    return RedirectToAction(nameof(Index));
                }
            }
            return NotFound();


           
            // GET: Account/Details/5
            //        public async Task<IActionResult> Details(int? id)
            //        {
            //            if (id == null)
            //            {
            //                return NotFound();
            //            }

            //            var account = await _context.Accounts
            //                .FirstOrDefaultAsync(m => m.ID == id);
            //            if (account == null)
            //            {
            //                return NotFound();
            //            }

            //            return View(account);
            //        }


            //        // GET: Account/Edit/5
            //        public async Task<IActionResult> Edit(int? id)
            //        {
            //            if (id == null)
            //            {
            //                return NotFound();
            //            }

            //            var account = await _context.Accounts.FindAsync(id);
            //            if (account == null)
            //            {
            //                return NotFound();
            //            }
            //            return View(account);
            //        }

            //        // POST: Account/Edit/5
            //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //        [HttpPost]
            //        [ValidateAntiForgeryToken]
            //        public async Task<IActionResult> Edit(int id, [Bind("ID,AccountType,CustomerID,Balance,InterestRate")] Account account)
            //        {
            //            if (id != account.ID)
            //            {
            //                return NotFound();
            //            }

            //            if (ModelState.IsValid)
            //            {
            //                try
            //                {
            //                    _context.Update(account);
            //                    await _context.SaveChangesAsync();
            //                }
            //                catch (DbUpdateConcurrencyException)
            //                {
            //                    if (!AccountExists(account.ID))
            //                    {
            //                        return NotFound();
            //                    }
            //                    else
            //                    {
            //                        throw;
            //                    }
            //                }
            //                return RedirectToAction(nameof(Index));
            //            }
            //            return View(account);
            //        }

            //        // GET: Account/Delete/5
            //        public async Task<IActionResult> Delete(int? id)
            //        {
            //            if (id == null)
            //            {
            //                return NotFound();
            //            }

            //            var account = await _context.Accounts
            //                .FirstOrDefaultAsync(m => m.ID == id);
            //            if (account == null)
            //            {
            //                return NotFound();
            //            }

            //            return View(account);
            //        }

            //        // POST: Account/Delete/5
            //        [HttpPost, ActionName("Delete")]
            //        [ValidateAntiForgeryToken]
            //        public async Task<IActionResult> DeleteConfirmed(int id)
            //        {
            //            var account = await _context.Accounts.FindAsync(id);
            //            _context.Accounts.Remove(account);
            //            await _context.SaveChangesAsync();
            //            return RedirectToAction(nameof(Index));
            //        }

            //        private bool AccountExists(int id)
            //        {
            //            return _context.Accounts.Any(e => e.ID == id);
            //        }

        }
    }
}
