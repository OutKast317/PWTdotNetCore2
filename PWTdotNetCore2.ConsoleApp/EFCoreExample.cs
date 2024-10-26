using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTdotNetCore2.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();

            var lst = db.Blogs.Where(x => x.DeleteFlag == false).ToList();

            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Create(string title, string author, string content)
        {
            
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };
            
            AppDbContext db = new AppDbContext();

            db.Blogs.Add(blog);
            
            var result = db.SaveChanges();

            Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");
        }
    }
}
