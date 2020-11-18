using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iTransPostMgr
    {
        bool AddTransPost(ArTransPost transPost);
        bool CreateTransPost(ArTransaction transaction, DateTime postDate, decimal balance);
        bool EditTransPost(ArTransPost transPost);
        bool RemoveTransPost(ArTransPost transPost);
        ArTransPost GetTransPostById(int id);
        List<ArTransPost> GetTransPosts();
    }
}
