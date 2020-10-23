using ArModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArInterfaces
{
    public interface iTransPostDb
    {
        bool DbDispose();
        bool AddTransPost(ArTransPost transPost);
        bool EditTransPost(ArTransPost transPost);
        bool DeleteTransPost(ArTransPost transPost);
        ArTransPost GetTransPostById(int id);
        IQueryable<ArTransPost> GetTransPosts();
    }
}
