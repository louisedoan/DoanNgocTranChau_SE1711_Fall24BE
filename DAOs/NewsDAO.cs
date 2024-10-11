using BOs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class NewsDAO
    {
        private static NewsDAO instance = null;

        public NewsDAO()
        {
        }



        public static NewsDAO Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new NewsDAO();
                }
                return instance;
            }

        }

        public List<NewsArticle> GetNews()
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                return dbContent.NewsArticles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
      /*  public SystemAccount GetAccount(string email)
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

        public void AddAccount(SystemAccount account)
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                SystemAccount accountProfile = GetAccount(account.AccountEmail.ToString());
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

        public void DeleteAccount(string account)
        {
            try
            {
                var dbContent = new FunewsManagementFall2024Context();
                SystemAccount accountProfile = GetAccount(account);
                if (account != null)
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
                throw new Exception("Email hasn't existed !");
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
        }*/
    }
}

