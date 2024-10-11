using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;

        public AccountDAO()
        {
        }

        public static AccountDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }

        }

        public List<SystemAccount> GetAccounts()
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                return dbContent.SystemAccounts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public SystemAccount GetAccount(short id)
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                return dbContent.SystemAccounts.SingleOrDefault(m => m.AccountId.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddAccount(SystemAccount account)
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                SystemAccount accountProfile = GetAccount(account.AccountId);
                if (accountProfile == null)
                {
                    dbContent.SystemAccounts.Add(account);
                    dbContent.SaveChanges();
                }
                else
                {
                    throw new Exception("AccountID has existed !");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void DeleteAccount(short id)
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                SystemAccount accountProfile = GetAccount(id);
                if (id != null)
                {
                    dbContent.SystemAccounts.Remove(accountProfile);
                    dbContent.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void UpdateAccount(SystemAccount account)
        {
            var dbContent = new FunewsManagementFall2024Context();

            if (account != null)
            {
                dbContent.SystemAccounts.Update(account);
                dbContent.SaveChanges();
            }
            else
            {
                throw new Exception("Id hasn't existed !");
            }
        }

        public SystemAccount GetAccountByEmail(string email)
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                return dbContent.SystemAccounts.SingleOrDefault(m => m.AccountEmail.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SystemAccount> SearchAccount(string account)
        {
            try
            {
                using (var dbContext = new FunewsManagementFall2024Context())
                {
                    return dbContext.SystemAccounts.Where(p => p.AccountName.Contains(account)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

