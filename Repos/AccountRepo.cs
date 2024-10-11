using BOs.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class AccountRepo : IAccountRepo
    {

        public void AddAccount(SystemAccount account) => AccountDAO.Instance.AddAccount(account);
        public void DeleteAccount(short account) => AccountDAO.Instance.DeleteAccount(account);

        public SystemAccount GetAccount(short account) => AccountDAO.Instance.GetAccount(account);

        public List<SystemAccount> GetAccounts() => AccountDAO.Instance.GetAccounts();

        public List<SystemAccount> SearchAccount(string account) => AccountDAO.Instance.SearchAccount(account);

        public void UpdateAccount(SystemAccount account) => AccountDAO.Instance.UpdateAccount(account);

        public SystemAccount GetAccountByEmail(string email) => AccountDAO.Instance.GetAccountByEmail(email);
    }

}