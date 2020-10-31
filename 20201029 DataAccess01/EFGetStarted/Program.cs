using System;
using System.Linq;
using static System.Console;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new BloggingContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.Add(new Blog { Url = "http://www.aemet.es/" });
                db.SaveChanges();

                //WriteLine()
                PressKey();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();
                WriteLine($"Blog:{blog.BlogId}, {blog.Url}");

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();
                PressKey();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }

        public static void PressKey() {
            WriteLine("Press key to continue...");
            var aaa = ReadKey();
        }
    }
}