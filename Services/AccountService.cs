using BOs.Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepo accountRepository = null;

        public AccountService()
        {
            accountRepository = new AccountRepo();
        }
        public void AddAccount(SystemAccount account)
        {
            accountRepository.AddAccount(account);
        }

        public void DeleteAccount(short account)
        {
            accountRepository.DeleteAccount(account);
        }

        public SystemAccount GetAccount(short account)
        {
            return accountRepository.GetAccount(account);
        }

        public List<SystemAccount> GetAccounts()
        {
            return accountRepository.GetAccounts();
        }

        public List<SystemAccount> SearchAccount(string account)
        {
            return accountRepository.SearchAccount(account);
        }

        public void UpdateAccount(SystemAccount account)
        {
            accountRepository.UpdateAccount(account);
        }

        public SystemAccount GetAccountByEmail(string email) => accountRepository.GetAccountByEmail(email);

    }

}
