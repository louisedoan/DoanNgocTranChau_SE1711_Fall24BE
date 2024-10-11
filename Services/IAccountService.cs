using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAccountService
    {
        List<SystemAccount> GetAccounts();
        void AddAccount(SystemAccount account);

        SystemAccount GetAccount(short account);

        void DeleteAccount(short account);

        void UpdateAccount(SystemAccount account);

        List<SystemAccount> SearchAccount(string account);

        SystemAccount GetAccountByEmail(string email);
    }
}
