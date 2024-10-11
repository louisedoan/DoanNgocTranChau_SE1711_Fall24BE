using BOs.Models;
using DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
    public class NewsRepo : INewsRepo
    {
        public IEnumerable<NewsArticle> GetNews() => NewsDAO.Instance.GetNews();
        
    }
}
