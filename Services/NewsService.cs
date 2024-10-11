using BOs.Models;
using Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NewsService : INewsService
    {
       
        private INewsRepo newsRepo = null;

        public NewsService()
        {
            newsRepo = new NewsRepo();
        }
        
        public IEnumerable<NewsArticle> GetNews()
        {
            var newsArticles = newsRepo.GetNews();
            return newsArticles.Where(n => n.NewsStatus == true);
        }
    }
}
