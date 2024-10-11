using BOs.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public interface IAccountRepo
    {

        List<SystemAccount> GetAccounts();
        void AddAccount(SystemAccount account);

        SystemAccount GetAccount(short account);

        void DeleteAccount(short account);

        void UpdateAccount(SystemAccount account);

        SystemAccount GetAccountByEmail(string email);

        List<SystemAccount> SearchAccount(string account);
   

    }
}
